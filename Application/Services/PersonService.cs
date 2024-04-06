using AutoMapper;
using ClassLibrary1.Interfaces.Services;
using Domain.Entities;

namespace ClassLibrary1.Services;

public class PersonService : IPersonServices
{
    //TODO: добавить маппинг
    private readonly IPersonServices _personServices;
    private readonly IMapper _mapper;

    public PersonService(IPersonServices personServices, IMapper mapper)
    {
        _personServices = personServices;
        _mapper = mapper;
    }

    public async Task<Person> CreateAsync(Person entity, CancellationToken cancellationToken)
    {
        var person = await _personServices.CreateAsync(entity,cancellationToken);
        return person;
    }

    public async Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person= await _personServices.GetByIdAsync(id,cancellationToken);
        return person;
    }

    public async Task<Person> UpdateAsync(Person entity, CancellationToken cancellationToken)
    {
        var person = await _personServices.UpdateAsync(entity, cancellationToken);
        return person;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await _personServices.DeleteByIdAsync(id, cancellationToken);
        return person;
    }

    public async Task<List<Person>> GetAllListAsync(CancellationToken cancellationToken)
    {
        var personList =await _personServices.GetAllListAsync(cancellationToken);
        return personList;
    }

    public async Task<List<CustomFields<string>>> GetCustomFieldAsync(Guid id)
    {
        var customField = await _personServices.GetCustomFieldAsync(id);
        return customField;
    }
}