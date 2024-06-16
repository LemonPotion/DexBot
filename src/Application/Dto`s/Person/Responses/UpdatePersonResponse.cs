namespace Application.Dto_s.Person.Responses;
/// <summary>
/// Дто для ответа на обновление Person
/// </summary>
public class UpdatePersonResponse : BasePersonDto
{
    /// <summary>
    /// Идентификатор Person
    /// </summary>
    public Guid Id { get; init; }
}