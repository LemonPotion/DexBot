using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators.Common;

/// <summary>
/// Валидация полного имени
/// </summary>
public class FullNameValidator: AbstractValidator<FullName>
{
    public FullNameValidator(string paramName)
    {
        RuleFor(param => param.FirstName)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
        
        RuleFor(param => param.MiddleName)
            .NotEmpty().When(middleName => middleName != null).WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.FullName).When(middleName => middleName != null).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
        
        RuleFor(param => param.LastName)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
    }
}