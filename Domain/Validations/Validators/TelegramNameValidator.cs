using FluentValidation;

namespace Domain.Validations.Validators;

/// <summary>
/// Валидация ника в Telegram
/// </summary>
public class TelegramNameValidator : AbstractValidator<string>
{
    public TelegramNameValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError,paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError,paramName))
            .Matches(RegexPatterns.TelegramName).WithMessage(string.Format(ExceptionMessages.InvalidTelegramNameFormat,paramName));
    }
}