using Domain.Entities;
using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators;

public class CustomFieldsValidator<TType> : AbstractValidator<CustomFields<TType>>
{
    public CustomFieldsValidator(string paramName)
    {
        RuleFor(a => a)
            .NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
            .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}