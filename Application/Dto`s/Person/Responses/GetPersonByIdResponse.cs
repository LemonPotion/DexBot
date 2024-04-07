namespace Application.Dto_s.Person.Responses;

/// <summary>
/// Дто для ответа на получение Person по идентификатору 
/// </summary>
public class GetPersonByIdResponse : BasePersonDto
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid Id { get; init; }
}