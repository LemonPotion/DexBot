namespace Application.Dto_s.Person;

public class FullNameDto
{
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