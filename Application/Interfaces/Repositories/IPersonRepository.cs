using System.Runtime.InteropServices.JavaScript;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IPersonRepository : IBaseRepository<Person>
{
    /// <summary>
    /// Получить пользовательские поля
    /// </summary>
    /// <param name="id"></param>
    /// <returns>кастомное поле</returns>
    public Task<List<CustomFields<string>>> GetCustomFieldAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Get persons which birthdate is today
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List Person </returns>
    public Task<List<Person>> GetBirthdayPersonsAsync(DateTime dateTime, CancellationToken cancellationToken);
}