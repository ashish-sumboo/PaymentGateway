using Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Core.Entities;
using Core.Database.Stores.Interfaces;
using System.Threading.Tasks;
using Core.Transactions;
using Core.Transactions.Dtos;
using Core.Helpers;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace Core.Services
{
    public class PaymentOrderService : IPaymentOrderService
    {
        private readonly IPaymentRequestStore paymentRequestStore;
        private readonly IPaymentResponseStore paymentStatusStore;
        private readonly IPushTransactionHandler handler;
        private readonly ILogger logger;

        public PaymentOrderService(IPaymentRequestStore paymentRequestStore, IPaymentResponseStore paymentStatusStore, IPushTransactionHandler handler, ILoggerFactory loggerFactory)
        {
            this.paymentRequestStore = paymentRequestStore;
            this.paymentStatusStore = paymentStatusStore;
            this.handler = handler;
            logger = loggerFactory.CreateLogger(GetType());
        }

        public async Task<PaymentResponse> CreatePaymentOrder(PaymentRequest request)
        {
            request.Card.Number = Encryption.EncryptString(request.Card.Number);

            await paymentRequestStore.AddAsync(request);

            var payloadToSendToAcquiringBank = CreateAcquiringBankRequest(request);
            logger.LogInformation(JsonConvert.SerializeObject(payloadToSendToAcquiringBank));

            var rawResponse = await handler.PushToAcquiringBank(payloadToSendToAcquiringBank);
            var transformedResponse = MapBankResponseToDomainEntity(rawResponse, request.Id);

            await paymentStatusStore.AddAsync(transformedResponse);

            return transformedResponse;
        }

        private static PaymentAuthorizationRequest CreateAcquiringBankRequest(PaymentRequest request)
        {
            var result = new PaymentAuthorizationRequest()
            {
                BankCode = Constants.AcquiringBankCode,
                GatewayAuthorizationCode = Constants.GatewayCode,
                Amount = request.Amount,
                CardNumber = request.Card.Number,
                CardExpiryMonth = request.Card.ExpiryMonth,
                CardExpiryYear = request.Card.ExpiryYear,
                CurrencyCode = request.Currency,
                Cvv = request.Card.Cvv
            };

            return result;
        }

        private static PaymentResponse MapBankResponseToDomainEntity(PaymentAuthorizationResponse response, string paymentId)
        {
            var result = new PaymentResponse()
            {
                Id = response.Id,
                StatusCode = Types.Status.Completed,
                Status = Constants.Success,
                PaymentRequestId = paymentId,
                Amount = response.Amount,
                Currency = response.Currency
            };

            result.Card.Cvv = Constants.CvvMask;
            result.Card.ExpiryMonth = response.CardExpiryMonth;
            result.Card.ExpiryYear = response.CardExpiryYear;

            var cardNumber = Encryption.DecryptString(response.CardNumber);

            // Mask credit card
            // TODO: To move to a helper class
            var firstDigits = cardNumber.Substring(0, 4);
            var lastDigits = cardNumber.Substring(cardNumber.Length - 4, 4);
            var requiredMask = new String(Constants.MaskCharacter[0], cardNumber.Length - firstDigits.Length - lastDigits.Length);
            var maskedString = string.Concat(firstDigits, requiredMask, lastDigits);
            var maskedCardNumberWithSpaces = Regex.Replace(maskedString, ".{4}", "$0 ").TrimEnd();

            result.Card.Number = maskedCardNumberWithSpaces;

            return result;
        }
    }
}
