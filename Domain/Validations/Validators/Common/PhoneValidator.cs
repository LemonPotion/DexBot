using FluentValidation;
using Microsoft.VisualBasic;

namespace Domain.Validations.Validators.Common;

public class PhoneValidator: AbstractValidator<string>
{
    public PhoneValidator(string paramName)
    {
        RuleFor(param => param)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.Phone).WithMessage(Strings.Format(ExceptionMessages.InvalidPhoneFormat, paramName));
    }
}