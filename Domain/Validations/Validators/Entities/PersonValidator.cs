using Domain.Entities;
using Domain.Validations.Validators.Common;
using FluentValidation;

namespace Domain.Validations.Validators.Entities;

public class PersonValidator : AbstractValidator<Person>
{
    public PersonValidator(string paramName)
    {
        RuleFor(param => param.FullName).SetValidator(new FullNameValidator(nameof(Person.FullName)));
        RuleFor(param => param.BirthDay).SetValidator(new BirthDateValidator(nameof(Person.BirthDay)));
        RuleFor(param => param.Gender).SetValidator(new EnumValidator<Gender>(nameof(Person.Gender)));
        RuleFor(param => param.PhoneNumber).SetValidator(new PhoneValidator(nameof(Person.PhoneNumber)));
        RuleFor(param => param.Telegram).SetValidator(new TelegramNameValidator(nameof(Person.Telegram)));
    }
}