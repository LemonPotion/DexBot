using FluentValidation;
using Microsoft.VisualBasic;

namespace Domain.Validations.Validators.Common;
/// <summary>
/// Класс валидации номеров телефона
/// </summary>
public class PhoneValidator: AbstractValidator<string>
{
    /// <summary>
    /// Валидация номера телефона
    /// </summary>
    /// <param name="paramName"></param>
    public PhoneValidator(string paramName)
    {
        RuleFor(param => param)
            .SetValidator(new BaseValidation<string>(paramName))
            .Matches(RegexPatterns.Phone).WithMessage(Strings.Format(ExceptionMessages.InvalidPhoneFormat, paramName));
    }
}