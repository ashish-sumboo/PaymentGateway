using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Transactions.Dtos
{
    public class PaymentAuthorizationResponse
    {
        public string Id { get; set; }

        public bool IsApproved { get; set; }

        public string Status { get; set; }

        public string StatusCode { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string PaymentRequestId { get; set; }

        public string CardNumber { get; set; }

        public int CardExpiryMonth { get; set; }

        public int CardExpiryYear { get; set; }

        public string Cvv { get; set; }
    }
}
