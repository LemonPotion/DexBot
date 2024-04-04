namespace ClassLibrary1.Dto_s.Person.Requests;

/// <summary>
/// Дто для получения Person
/// </summary>
public class GetPersonRequest
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid id { get; init; }
}