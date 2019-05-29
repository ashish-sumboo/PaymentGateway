using Core.Database;
using Core.Database.Stores;
using Core.Entities;
using Core.Helpers;
using Core.Payments;
using Core.Services;
using Core.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Core.Tests
{
    public class PaymentOrderTests
    {
        PaymentRequestStore paymentRequestStore;
        PaymentResponseStore paymentStatusStore;
        PaymentOrderService paymentOrderService;
        public PaymentOrderTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseInMemoryDatabase();
            var dbContext = new ApiDbContext(optionsBuilder.Options);

            var serviceProvider = new ServiceCollection()
                                                        .AddLogging()
                                                        .BuildServiceProvider();

            var factory = serviceProvider.GetService<ILoggerFactory>();

            paymentRequestStore = new PaymentRequestStore(dbContext, factory);
            paymentStatusStore = new PaymentResponseStore(dbContext, factory);
            paymentOrderService = new PaymentOrderService(paymentRequestStore, paymentStatusStore, new SampleAcquiringBank(), factory);
        }
        [Fact]
        public async void GivenNewPaymentSubmitted_ResponseCode_ShouldBeCompleted()
        {
            var paymentRequest = new PaymentRequest()
            {
                Amount = 100
            };
            paymentRequest.Card.Number = "1234555599996667";

            var result = await paymentOrderService.CreatePaymentOrder(paymentRequest);

            var expectedStatus = Status.Completed;

            Assert.IsType<PaymentResponse>(result);
            Assert.Equal(result.StatusCode, expectedStatus);
            Assert.NotNull(result.Status);
        }

        [Fact]
        public async void GivenNewPaymentSubmitted_CreditCardNumber_ShouldBeEncryptedInStorage()
        {
            var paymentRequest = new PaymentRequest()
            {
                Id = "83b03ae2-a568-4206-acde-9649b97a544f",
                Amount = 100
            };
            paymentRequest.Card.Number = "1234555599996666";

            await paymentOrderService.CreatePaymentOrder(paymentRequest);
            var result = paymentRequestStore.FindEntityAsync(p => p.Id == "83b03ae2-a568-4206-acde-9649b97a544f");

            Assert.Equal(result.Result.Card.Number, "SFIkMnBJakhSJDJwSWoxMipdMnK3aafIep76iDSnGROVLJS9e10jyh39wi3m6caN");
        }

        [Fact]
        public async void WhenPaymentStatusRequested_CreditCardNumberAndCvv_ShouldBeMasked()
        {
            var paymentRequest = new PaymentRequest()
            {
                Amount = 100
            };
            paymentRequest.Card.Number = "4234555599996667";

            var payment = await paymentOrderService.CreatePaymentOrder(paymentRequest);

            var result = await paymentStatusStore.FindEntityAsync(p => p.PaymentRequestId == paymentRequest.Id);

            Assert.Equal(result.Card.Number, "4234 **** **** 6667");
            Assert.Equal(result.Card.Cvv, "****");
        }
    }
}
