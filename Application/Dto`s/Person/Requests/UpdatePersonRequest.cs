using Domain.Entities;
using Domain.ValueObjects;

namespace ClassLibrary1.Dto_s.Person.Requests;
/// <summary>
/// Дто для обновления Person
/// </summary>
public class UpdatePersonRequest
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid Id { get; init; }
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