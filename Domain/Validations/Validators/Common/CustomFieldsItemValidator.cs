using FluentValidation;

namespace Domain.Validations.Validators.Common;

public class CustomFieldsItemValidator<TType,TElement> : AbstractValidator<TType>
{
    public CustomFieldsItemValidator(string paramName)
    {
        //TODO: Сделать валидацию каждого элемента в коллекции
    }
}