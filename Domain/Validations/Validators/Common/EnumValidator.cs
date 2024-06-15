using FluentValidation;

namespace Domain.Validations.Validators.Common;
/// <summary>
/// Класс валидации перечислений
/// </summary>
/// <typeparam name="TEnum"></typeparam>
public class EnumValidator<TEnum> : AbstractValidator<TEnum> where TEnum : Enum
{
    /// <summary>
    /// Валидация enum'a 
    /// </summary>
    /// <param name="paramName"></param>
    /// <param name="defaultValues"></param>
    public EnumValidator(string paramName, params TEnum[] defaultValues)
    {
        RuleFor(param => param)
            .Must(BeAValidEnumValue<TEnum>)
            .WithMessage(string.Format(ExceptionMessages.InvalidEnumValue, paramName));
    }
    private static bool BeAValidEnumValue<TEnum>(TEnum value) where TEnum : Enum
    {
        return Enum.IsDefined(typeof(TEnum), value);
    }
}