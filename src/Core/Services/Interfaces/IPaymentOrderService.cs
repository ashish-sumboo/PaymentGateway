using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface IPaymentOrderService
    {
        Task<PaymentResponse> CreatePaymentOrder(PaymentRequest request);
    }
}
