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
            FirstName = new FullNameValidator(nameof(firstName)).ValidateWithErrors(firstName);
            LastName = new FullNameValidator(nameof(lastName)).ValidateWithErrors(lastName);
            if (middleName is not null)
            {
                MiddleName = new FullNameValidator(nameof(middleName)).ValidateWithErrors(middleName);   
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