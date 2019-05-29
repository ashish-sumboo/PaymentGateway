using Core.Transactions.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Transactions
{
    public interface IPushTransactionHandler
    {
        Task<PaymentAuthorizationResponse> PushToAcquiringBank(PaymentAuthorizationRequest request);
    }
}
