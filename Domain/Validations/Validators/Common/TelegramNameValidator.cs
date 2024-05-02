using FluentValidation;

namespace Domain.Validations.Validators.Common;

/// <summary>
/// Валидация ника в Telegram
/// </summary>
public class TelegramNameValidator : AbstractValidator<string>
{
    public TelegramNameValidator(string paramName)
    {
        RuleFor(param => param)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.TelegramName).WithMessage(string.Format(ExceptionMessages.InvalidTelegramNameFormat,paramName));
    }
}