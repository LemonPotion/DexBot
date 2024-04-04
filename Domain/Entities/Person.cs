using Domain.Validations;
using Domain.Validations.Validators;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        /// <summary>
        /// Конструктор в котором происходит валидация
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="gender"></param>
        /// <param name="birthDay"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="telegram"></param>
        public Person(FullName fullName,Gender gender, DateTime birthDay, string phoneNumber, string telegram , List<CustomFields<string>> customFields)
        {
                FullName = fullName;
            var genderValidationResult = new EnumValidator<Gender>(nameof(gender), [Gender.None]).ValidateWithErrors(gender);
                Gender = gender;
            var birthdayValidationResult = new BirthDateValidator(nameof(birthDay)).ValidateWithErrors(birthDay);
                BirthDay = birthDay;
            var phoneNumberValidationResult = new PhoneValidator(nameof(phoneNumber)).ValidateWithErrors(phoneNumber);
                PhoneNumber = phoneNumber;
            var telegramValidationResult = new TelegramNameValidator(nameof(telegram)).ValidateWithErrors(telegram);
                Telegram = telegram;
                
                CustomFields = customFields;
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

        public List<CustomFields<string>> CustomFields { get; set; }
    }
}
