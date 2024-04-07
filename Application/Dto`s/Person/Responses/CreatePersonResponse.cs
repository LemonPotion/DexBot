namespace Application.Dto_s.Person.Responses
{
    /// <summary>
    /// Дто для ответа создания Person
    /// </summary>
    public class CreatePersonResponse : BasePersonDto
    {
        /// <summary>
        /// Идентификатор созданной персоны
        /// </summary>
        public Guid Id { get; init; }
    }
}