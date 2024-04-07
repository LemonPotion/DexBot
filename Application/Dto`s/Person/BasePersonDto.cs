using Domain.Entities;

namespace Application.Dto_s.Person;
/// <summary>
/// Базовый дто Person
/// </summary>
public class BasePersonDto
{
    /// <summary>
    /// Полное имя
    /// </summary>
    public FullNameDto FullName { get; init; }
    /// <summary>
    /// Дата рождения
    /// </summary>
    public DateTime BirthDay { get; init; }

    /// <summary>
    /// Гендер
    /// </summary>
    public Gender Gender { get; init; }
    /// <summary>
    /// Возраст
    /// </summary>
    public int Age => DateTime.Now.Year - BirthDay.Year;
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string PhoneNumber { get; init; }
    /// <summary>
    /// Ник tg
    /// </summary>
    public string Telegram { get; init; }

    public List<CustomFields<string>> CustomFields { get; init; }
}