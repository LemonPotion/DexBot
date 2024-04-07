namespace Application.Dto_s.Person.Responses;
/// <summary>
/// Дто для ответа на удаление Person
/// </summary>
public class DeletePersonResponse
{
    /// <summary>
    /// Флаг указывающий на статус выполнения операции
    /// </summary>
    public bool IsDeleted { get; init; }
}