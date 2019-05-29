using Core.Transactions;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Transactions.Dtos;
using System.Threading.Tasks;

namespace Core.Payments
{
    public class SampleAcquiringBank : IPushTransactionHandler
    {
        public Task<PaymentAuthorizationResponse> PushToAcquiringBank(PaymentAuthorizationRequest request)
        {
            // Logic to submit the payment to the acquiring bank goes here

            var response = new PaymentAuthorizationResponse
            {
                Id = $"MCB-098678-{Guid.NewGuid()}",
                IsApproved = true,
                StatusCode = "ACK-SUCCESS",
                Status = "PAID",
                Amount = request.Amount,
                Currency = request.CurrencyCode,
                CardExpiryMonth = request.CardExpiryMonth,
                CardExpiryYear = request.CardExpiryYear,
                CardNumber = request.CardNumber,
                Cvv = request.Cvv
            };

            return Task.FromResult(response);
        }
    }
}
