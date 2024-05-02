using FluentValidation;

namespace Domain.Validations.Validators.Common;

public class BaseValidation<TType> : AbstractValidator<TType>
{
    public BaseValidation(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}