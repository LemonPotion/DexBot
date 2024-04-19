using Domain.Validations;
using Domain.Validations.Validators.Entities;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
        /// <summary>
        /// Конструктор в котором происходит валидация
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fullName"></param>
        /// <param name="gender"></param>
        /// <param name="birthDay"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="telegram"></param>
        /// <param name="customFields"></param>
        public Person(Guid id, FullName fullName,Gender gender, DateTime birthDay, string phoneNumber, string telegram , List<CustomFields<string>> customFields)
        {
            var validator = new PersonValidator(nameof(Person));
            validator.ValidateWithErrors(this);
        }

        public Person Update( string firstName, string lastName, string middleName, string phoneNumber, Gender gender, DateTime birthDate, string telegram)
        {
            FullName.Update(firstName, lastName, middleName);
            BirthDay = birthDate;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Telegram = telegram;
            
            var validator = new PersonValidator(nameof(Person));
            validator.ValidateWithErrors(this);
            return this;
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
