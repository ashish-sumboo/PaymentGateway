// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace PaymentGateway.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class Card
    {
        /// <summary>
        /// Initializes a new instance of the Card class.
        /// </summary>
        public Card()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Card class.
        /// </summary>
        public Card(string number = default(string), int? expiryMonth = default(int?), int? expiryYear = default(int?), string cvv = default(string))
        {
            Number = number;
            ExpiryMonth = expiryMonth;
            ExpiryYear = expiryYear;
            Cvv = cvv;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "number")]
        public string Number { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "expiryMonth")]
        public int? ExpiryMonth { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "expiryYear")]
        public int? ExpiryYear { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "cvv")]
        public string Cvv { get; set; }

    }
}
