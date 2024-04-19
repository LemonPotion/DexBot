using Domain.Validations;
using Domain.Validations.Validators.Common;

namespace Domain.ValueObjects
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public class FullName : BaseValueObject
    {
        /// <summary>
        /// Конструктор с валидацией
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="middleName"></param>
        public FullName(string firstName, string lastName, string? middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
    
            var fullNameValidator = new FullNameValidator(nameof(FullName));
            fullNameValidator.ValidateWithErrors(this);
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } 
        /// <summary>
        /// Отчество
        /// </summary>
        public string? MiddleName { get; set; } = null;

        public FullName Update(string firstName, string lastName, string middleName)
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            return this;
        }
    }
}