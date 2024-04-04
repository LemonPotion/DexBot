namespace ClassLibrary1.Dto_s.Person.Requests;
/// <summary>
/// Дто для обновления Person
/// </summary>
public class UpdatePersonRequest: BasePersonDto
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid id { get; init; }
    
}