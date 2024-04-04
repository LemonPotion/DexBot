using Domain.Validations;
using Domain.Validations.Validators;
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
            var fullNameValidator = new FullNameValidator(nameof(FullName));
            FirstName = fullNameValidator.ValidateWithErrors(new FullName(firstName, lastName, middleName)).FirstName;
            LastName = fullNameValidator.ValidateWithErrors(new FullName(firstName, lastName, middleName)).LastName;
            if (middleName is not null)
            {
                MiddleName = fullNameValidator.ValidateWithErrors(new FullName(firstName, lastName, middleName)).MiddleName;
            }
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
    }
}