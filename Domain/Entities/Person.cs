using Domain.Validations.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        //TODO: Добавить валидацию FullName
        /// <summary>
        /// Конструктор в котором происходит валидация
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="gender"></param>
        /// <param name="birthDay"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="telegram"></param>
        public Person(FullName fullName,Gender gender, DateTime birthDay, string phoneNumber, string telegram)
        {
            var genderValidationResult = new EnumValidator<Gender>(nameof(gender), [Gender.Other]).Validate(gender);
            if(genderValidationResult.IsValid)
                Gender = gender;
            var birthdayValidationResult = new BirthDateValidator(nameof(birthDay)).Validate(birthDay);
            if(birthdayValidationResult.IsValid) 
                BirthDay = birthDay;
            var phoneNumberValidationResult = new PhoneValidator(nameof(phoneNumber)).Validate(phoneNumber);
            if(phoneNumberValidationResult.IsValid) 
                PhoneNumber = phoneNumber;
            var telegramValidationResult = new TelegramNameValidator(nameof(telegram)).Validate(telegram);
            if(telegramValidationResult.IsValid) 
                Telegram = telegram;
        }

        /// <summary>
        /// Полное имя
        /// </summary>
        public FullName FullName { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDay { get; set; }

        /// <summary>
        /// Гендер
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age => DateTime.Now.Year - BirthDay.Year;
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Ник tg
        /// </summary>
        public string Telegram { get; set; }
    }
}
