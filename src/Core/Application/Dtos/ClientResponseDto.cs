namespace Core.Application.Dtos
{
    using Core.Types;
    using System;
    public class ClientResponseDto
    {
        public int Code { get; }

        public string Message { get; }

        public string PaymentId { get; }

        public ClientResponseDto(string paymentId, Status status, string message)
            : this(paymentId, Convert.ToInt32(status), message)
        {
        }

        public ClientResponseDto(string paymentId, string code, string message)
            : this(paymentId, Convert.ToInt32(code), message)
        {
        }

        public ClientResponseDto(string paymentId, int code, string message)
        {
            PaymentId = paymentId;
            Code = code;
            Message = message;
        }
    }
}
