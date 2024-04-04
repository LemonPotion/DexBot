using Domain.Entities;

namespace ClassLibrary1.Interfaces.Repositories;

public interface IPersonRepository : IBaseRepository<Person>
{
    /// <summary>
    /// Получить пользовательские поля
    /// </summary>
    /// <param name="id"></param>
    /// <returns>кастомное поле</returns>
    public Task<List<CustomFields<string>>> GetCustomFieldAsync(Guid id);
}