using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Dal.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Dal.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly DexBotDbContext _dbContext;

    public PersonRepository(DexBotDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Person> CreateAsync(Person entity, CancellationToken cancellationToken)
    {
        _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await _dbContext.FindAsync<Person>( id , cancellationToken);
        return person;
    }

    public async Task<Person> UpdateAsync(Person entity, CancellationToken cancellationToken)
    {
        var update= entity.Update(entity.FullName.FirstName, entity.FullName.LastName, entity.FullName.MiddleName,
            entity.PhoneNumber, entity.Gender, entity.BirthDay, entity.Telegram);
        _dbContext.Update(update);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await GetByIdAsync(id, cancellationToken);
        _dbContext.Remove(person);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<List<Person>> GetAllListAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<Person>().ToListAsync(cancellationToken);
    }
    
    public async Task<List<CustomFields<string>>> GetCustomFieldAsync(Guid id, CancellationToken cancellationToken)
    {
        var field = await _dbContext.Set<CustomFields<string>>().Where(f => f.Id == id).ToListAsync(cancellationToken);
        return field;
    }
}