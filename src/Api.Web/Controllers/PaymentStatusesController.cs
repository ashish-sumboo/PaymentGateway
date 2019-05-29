using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.Database.Stores.Interfaces;

using Core.Entities;
using Core;
using Core.Types;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/paymentstatus/{paymentId}")]
    [Produces("application/json")]
    public class PaymentStatusesController : Controller
    {
        private readonly IPaymentResponseStore store;

        public PaymentStatusesController(IPaymentResponseStore store)
        {
            this.store = store;
        }

        [HttpGet]
        public async Task<PaymentResponse> Get(string paymentId)
        {
            var result = await store.FindEntityAsync(p => p.PaymentRequestId == paymentId);

            return result;
        }
    }
}
