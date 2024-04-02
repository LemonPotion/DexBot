using FluentValidation;
namespace Domain.Validations.Validators;

public class BirthDateValidator: AbstractValidator<DateTime>
{
    /// <summary>
    /// Валидация даты рождения
    /// </summary>
    /// <param name="paramName"></param>
    public BirthDateValidator(string paramName)
    {
        RuleFor(a => a)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError,paramName))
            .LessThan(DateTime.Now.AddDays(1)).WithMessage(string.Format(ExceptionMessages.FutureDateError, paramName))
            .GreaterThan(DateTime.Now.AddYears(-150)).WithMessage(string.Format(ExceptionMessages.OldDateError,paramName));
    }
}