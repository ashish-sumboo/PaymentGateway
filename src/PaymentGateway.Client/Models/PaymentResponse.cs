// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace PaymentGateway.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class PaymentResponse
    {
        /// <summary>
        /// Initializes a new instance of the PaymentResponse class.
        /// </summary>
        public PaymentResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PaymentResponse class.
        /// </summary>
        public PaymentResponse(string id = default(string), string paymentRequestId = default(string), double? amount = default(double?), string currency = default(string), int? statusCode = default(int?), string status = default(string), Card card = default(Card))
        {
            Id = id;
            PaymentRequestId = paymentRequestId;
            Amount = amount;
            Currency = currency;
            StatusCode = statusCode;
            Status = status;
            Card = card;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "paymentRequestId")]
        public string PaymentRequestId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "amount")]
        public double? Amount { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "currency")]
        public string Currency { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "statusCode")]
        public int? StatusCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "card")]
        public Card Card { get; set; }

    }
}
