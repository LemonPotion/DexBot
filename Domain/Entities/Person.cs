using Domain.Validations;
using Domain.Validations.Primitives;
using Domain.Validations.Validators.Entities;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class Person : BaseEntity
    {
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
        /// Ник telegram
        /// </summary>
        public string Telegram { get; set; }
        
        /// <summary>
        /// Кастомные поля
        /// </summary>
        public ICollection<CustomFields<string>> CustomFields { get; set; }

        public Person()
        {
            
        }
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
            Id = id;
            FullName = fullName;
            Gender = gender;
            BirthDay = birthDay;
            PhoneNumber = phoneNumber;
            Telegram = telegram;
            
            var validator = new PersonValidator(nameof(Person));
            validator.ValidateWithExceptions(this);
        }
        /// <summary>
        /// Метод для обновления сущности
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="gender"></param>
        /// <param name="birthDate"></param>
        /// <param name="telegram"></param>
        /// <returns>обновленная сущность</returns>
        public Person Update(string firstName, string lastName, string? middleName, string phoneNumber, Gender gender, DateTime birthDate, string telegram)
        {
            FullName.Update(firstName, lastName, middleName);
            BirthDay = birthDate;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Telegram = telegram;

            var validator = new PersonValidator(nameof(Person));
            validator.ValidateWithExceptions(this);
            
            return this;
        }
    }
}
