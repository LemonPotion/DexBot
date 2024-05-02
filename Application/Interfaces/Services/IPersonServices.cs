using Application.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IPersonServices
{

    public Task<Person> CreateAsync(Person entity , CancellationToken cancellationToken);
    public Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<Person> UpdateAsync(Person entity, CancellationToken cancellationToken);
    public Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<List<Person>> GetAllListAsync(CancellationToken cancellationToken);
}