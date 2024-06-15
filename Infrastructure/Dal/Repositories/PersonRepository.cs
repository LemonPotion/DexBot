using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;
/// <summary>
/// Person repository
/// </summary>
public class PersonRepository : IPersonRepository
{
    private readonly DexBotDbContext _dbContext;

    public PersonRepository(DexBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// Creates entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Person</returns>
    public async Task<Person> CreateAsync(Person entity, CancellationToken cancellationToken)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    /// <summary>
    /// Gets entity
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Person</returns>
    public async Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await _dbContext.FindAsync<Person>( id , cancellationToken);
        return person;
    }
    /// <summary>
    /// Updates entity
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Person</returns>
    public async Task<Person> UpdateAsync(Person entity, CancellationToken cancellationToken)
    {
        var update= entity.Update(entity.FullName.FirstName, entity.FullName.LastName, entity.FullName.MiddleName,
            entity.PhoneNumber, entity.Gender, entity.BirthDay, entity.Telegram);
        _dbContext.Update(update);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }
    /// <summary>
    /// Deletes entity
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>bool result</returns>
    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(person);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }
    /// <summary>
    /// Gets all entities
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>List of persons</returns>
    public async Task<List<Person>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Person>().ToListAsync(cancellationToken);
    }
    /// <summary>
    /// Gets CustomFields
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<CustomFields<string>>> GetCustomFieldAsync(Guid id, CancellationToken cancellationToken)
    {
        var field = await _dbContext.Set<CustomFields<string>>().Where(f => f.Id == id).ToListAsync(cancellationToken);
        return field;
    }
    /// <summary>
    /// Gets today's birthday mans
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>List of Persons</returns>
    public async Task<List<Person>> GetBirthdayPersonsAsync(DateTime dateTime, CancellationToken cancellationToken)
    {
        var persons =
            _dbContext.Persons.Where(x => x.BirthDay.Day == dateTime.Day && x.BirthDay.Month == dateTime.Month);
        return await persons.ToListAsync();
    }
}