using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators.Common;

/// <summary>
/// Валидация полного имени
/// </summary>
public class FullNameValidator: AbstractValidator<FullName>
{
    /// <summary>
    /// Валидация полного имени
    /// </summary>
    /// <param name="paramName"></param>
    public FullNameValidator(string paramName)
    {
        RuleFor(param => param.FirstName)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
        
        RuleFor(param => param.MiddleName)
            .Matches(RegexPatterns.FullName).When(middleName => middleName != null).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName))
            .When(middleName => middleName != null);;
        
        RuleFor(param => param.LastName)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
    }
}