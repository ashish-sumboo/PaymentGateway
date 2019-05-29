using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public static class Constants
    {
        public const string Success = "SUCCESS";

        public const string Failure = "FAILED";

        public const string PaymentNotFound = "Payment does not exist";

        public const string AcquiringBankCode = "BankCode";

        public const string GatewayCode = "GatewayAuthorizationCode";

        public const string CvvMask = "****";

        public const string MaskCharacter = "*";


        public static class ErrorCodes
        {
            public const string AmountLessThanZero = "50";
        }
    }
}
