using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация полного имени
/// </summary>
public class FullNameValidator: AbstractValidator<string>
{
    public FullNameValidator(string paramName)
    {
        RuleFor(a => a)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName))
            .Matches(RegexPatterns.FullName).WithMessage(string.Format(ExceptionMessages.InvalidNameFormat, paramName));
    }
}