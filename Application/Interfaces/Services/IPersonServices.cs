using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IPersonServices
{
    /// <summary>
    /// Create person
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>person</returns>
    public Task<Person> CreateAsync(Person entity , CancellationToken cancellationToken);
    /// <summary>
    /// Get person by Id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>person</returns>
    public Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    /// <summary>
    /// Update person
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>person</returns>
    public Task<Person> UpdateAsync(Person entity, CancellationToken cancellationToken);
    /// <summary>
    /// Delete person
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>bool</returns>
    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    /// <summary>
    /// Get all persons list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List person</returns>
    public Task<List<Person>> GetAllListAsync(CancellationToken cancellationToken);
}