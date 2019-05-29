namespace Api.Web.Validators
{
    using Core.Entities;
    using FluentValidation;
    public class PaymentRequestValidator : AbstractValidator<PaymentRequest>
    {
        public PaymentRequestValidator()
        {
            RuleFor(p => p.Amount).GreaterThan(0).WithMessage("Amount must be greater than zero").WithErrorCode(Core.Constants.ErrorCodes.AmountLessThanZero);
        }
    }
}
