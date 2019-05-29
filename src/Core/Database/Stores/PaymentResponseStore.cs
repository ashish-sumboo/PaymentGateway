using Core.Database.Stores.Interfaces;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Database.Stores
{
    public class PaymentResponseStore : AbstractEntityFrameworkStore<PaymentResponse>, IPaymentResponseStore
    {
        public PaymentResponseStore(ApiDbContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }
    }
}
