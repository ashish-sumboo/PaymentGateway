namespace Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Types;
    public class PaymentResponse
    {
        public string Id { get; set; }

        public string PaymentRequestId { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public Status StatusCode { get; set; }

        public string Status { get; set; }

        public Card Card { get; set; } = new Card();
    }
}
