using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Transactions.Dtos
{
    public class PaymentAuthorizationRequest
    {
        public string GatewayAuthorizationCode { get; set; }

        public string BankCode { get; set; }

        public string CardNumber { get; set; }

        public int CardExpiryMonth { get; set; }

        public int CardExpiryYear { get; set; }

        public string Cvv { get; set; }

        public string CurrencyCode { get; set; }

        public decimal Amount { get; set; }
    }
}
