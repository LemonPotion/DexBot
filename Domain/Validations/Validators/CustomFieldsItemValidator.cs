using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators;

public class CustomFieldsItemValidator<TType,TElement> : AbstractValidator<TType>
{
    public CustomFieldsItemValidator(string paramName)
    {
        //TODO: Сделать валидацию каждого элемента в коллекции
       // RuleForEach<TElement>(a => a.)
           //.NotNull().WithMessage(string.Format(ExceptionMessages.NullError, paramName))
           // .NotEmpty().WithMessage(string.Format(ExceptionMessages.EmptyError, paramName));
    }
}