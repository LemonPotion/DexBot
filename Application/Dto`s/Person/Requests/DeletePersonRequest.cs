namespace ClassLibrary1.Dto_s.Person.Requests;
/// <summary>
/// Дто для удаления Person
/// </summary>
public class DeletePersonRequest : BasePersonDto
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid id { get; init; }
}