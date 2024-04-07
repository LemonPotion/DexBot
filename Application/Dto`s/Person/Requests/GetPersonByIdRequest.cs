namespace Application.Dto_s.Person.Requests;

/// <summary>
/// Дто для получения Person
/// </summary>
public class GetPersonByIdRequest
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid Id { get; init; }
}