using FluentValidation;

namespace Domain.Validations.Validators.Common;
/// <summary>
/// Класс расширение базовой проверки на null и empty
/// </summary>
/// <typeparam name="TType"></typeparam>
public class BaseValidation<TType> : AbstractValidator<TType>
{
    public BaseValidation(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}