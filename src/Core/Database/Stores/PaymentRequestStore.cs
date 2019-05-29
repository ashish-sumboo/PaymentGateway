using Core.Database.Stores.Interfaces;
using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Database.Stores
{
    public class PaymentRequestStore : AbstractEntityFrameworkStore<PaymentRequest>, IPaymentRequestStore
    {
        public PaymentRequestStore(ApiDbContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory)
        {
        }

        public override Task<PaymentRequest> AddAsync(PaymentRequest entity)
        {
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            entity.CreatedDate = DateTimeOffset.Now;

            return base.AddAsync(entity);
        }
    }
}
