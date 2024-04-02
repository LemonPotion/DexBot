using FluentValidation;

namespace Domain.Validations.Validators;

public class EnumValidator<TEnum> : AbstractValidator<TEnum> where TEnum : Enum
{
    /// <summary>
    /// Валидация enum'a 
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="defaultValues"></param>
    public EnumValidator(string paramName, params TEnum[] defaultValues)
    {
        foreach (var value in defaultValues)
        {
            RuleFor(a=>a)
                .NotEqual(value).WithMessage(string.Format(ExceptionMessages.DefaultEnum, paramName));
        }
    }
}