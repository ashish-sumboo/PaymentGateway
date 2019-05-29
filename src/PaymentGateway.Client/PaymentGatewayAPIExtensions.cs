// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace PaymentGateway.Client
{
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for PaymentGatewayAPI.
    /// </summary>
    public static partial class PaymentGatewayAPIExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='request'>
            /// </param>
            public static void ApiVversionPaymentsPost(this IPaymentGatewayAPI operations, string version, PaymentRequest request = default(PaymentRequest))
            {
                operations.ApiVversionPaymentsPostAsync(version, request).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='request'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiVversionPaymentsPostAsync(this IPaymentGatewayAPI operations, string version, PaymentRequest request = default(PaymentRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                (await operations.ApiVversionPaymentsPostWithHttpMessagesAsync(version, request, null, cancellationToken).ConfigureAwait(false)).Dispose();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='paymentId'>
            /// </param>
            public static PaymentResponse ApiPaymentStatusesGet(this IPaymentGatewayAPI operations, string paymentId = default(string))
            {
                return operations.ApiPaymentStatusesGetAsync(paymentId).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='paymentId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PaymentResponse> ApiPaymentStatusesGetAsync(this IPaymentGatewayAPI operations, string paymentId = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiPaymentStatusesGetWithHttpMessagesAsync(paymentId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='paymentId'>
            /// </param>
            /// <param name='version'>
            /// </param>
            public static PaymentResponse ApiVversionPaymentstatusByPaymentIdGet(this IPaymentGatewayAPI operations, string paymentId, string version)
            {
                return operations.ApiVversionPaymentstatusByPaymentIdGetAsync(paymentId, version).GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='paymentId'>
            /// </param>
            /// <param name='version'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PaymentResponse> ApiVversionPaymentstatusByPaymentIdGetAsync(this IPaymentGatewayAPI operations, string paymentId, string version, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiVversionPaymentstatusByPaymentIdGetWithHttpMessagesAsync(paymentId, version, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}
