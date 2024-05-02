using FluentValidation;

namespace Domain.Validations.Validators.Common;

public class BirthDateValidator: AbstractValidator<DateTime>
{
    /// <summary>
    /// Валидация даты рождения
    /// </summary>
    /// <param name="paramName"></param>
    public BirthDateValidator(string paramName)
    {
        RuleFor(param => param)
            .SetValidator(new BaseValidation<DateTime>(paramName))
            .LessThan(DateTime.Now.AddDays(1)).WithMessage(string.Format(ExceptionMessages.FutureDateError, paramName))
            .GreaterThan(DateTime.Now.AddYears(-150)).WithMessage(string.Format(ExceptionMessages.OldDateError,paramName));
    }
}