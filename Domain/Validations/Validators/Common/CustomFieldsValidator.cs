using Domain.Entities;
using FluentValidation;

namespace Domain.Validations.Validators.Common;

public class CustomFieldsValidator<TType> : AbstractValidator<CustomFields<TType>>
{
    public CustomFieldsValidator(string paramName)
    {
        RuleFor(param => param)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}