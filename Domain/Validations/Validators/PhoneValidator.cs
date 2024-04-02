using FluentValidation;
using Microsoft.VisualBasic;

namespace Domain.Validations.Validators;

public class PhoneValidator: AbstractValidator<string>
{
    public PhoneValidator(string paramName)
    {
        RuleFor(a => a)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.Phone).WithMessage(Strings.Format(ExceptionMessages.InvalidPhoneFormat, paramName));
    }
}