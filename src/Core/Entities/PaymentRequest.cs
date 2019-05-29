namespace Core.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PaymentRequest
    {
        [Key]
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public string MerchantId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public Card Card { get; set; } = new Card();
    }
}
