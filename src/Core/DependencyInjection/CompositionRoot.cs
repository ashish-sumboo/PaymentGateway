namespace Core.DependencyInjection
{
    using System;

    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    using Core.Database;

    using Database.Stores.Interfaces;
    using Core.Database.Stores;
    using Core.Services.Interfaces;
    using Core.Services;
    using Core.Payments;
    using Core.Transactions;
    using Microsoft.Extensions.Logging;
    /// <summary>
    /// All services and objects are composed here
    /// </summary>
    public class CompositionRoot
    {
        public void Register(IServiceProvider serviceProvider, IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            var logger = serviceProvider.GetService<ILogger<CompositionRoot>>();

            logger.LogInformation("Registration of the dependencies of PaymentGatewayService started!");

            services.AddDbContext<ApiDbContext>(opt => opt.UseInMemoryDatabase());
            services.AddSingleton<IPaymentRequestStore, PaymentRequestStore>();
            services.AddSingleton<IPaymentResponseStore, PaymentResponseStore>();
            services.AddSingleton<IPaymentOrderService, PaymentOrderService>();
            services.AddSingleton<IPushTransactionHandler, SampleAcquiringBank>();

            logger.LogInformation("Registration of the dependencies of PaymentGatewayService finished!");
        }
    }
}
