using Domain.ValueObjects;
using FluentValidation;

namespace Domain.Validations.Validators;

public class CustomFieldsItemValidator<TType,TElement> : AbstractValidator<TType>
{
    public CustomFieldsItemValidator(string paramName)
    {
        //TODO: Сделать валидацию каждого элемента в коллекции
    }
}