using Application.Dto_s.Person.Requests;
using Application.Dto_s.Person.Responses;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;
public class PersonService
{
    
    private readonly IPersonServices _personServices;
    private readonly IMapper _mapper;

    public PersonService(IPersonServices personServices, IMapper mapper)
    {
        _personServices = personServices;
        _mapper = mapper;
    }

    /// <summary>
    /// Создание Person
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task CreatePersonResponse </returns>
    public async Task<CreatePersonResponse> CreateAsync(CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        var createdPerson = await _personServices.CreateAsync(person, cancellationToken);
        var response = _mapper.Map<CreatePersonResponse>(createdPerson);
        return response;
    }

    /// <summary>
    /// Получение Person по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task GetPersonByIdResponse</returns>
    public async Task<GetPersonByIdResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var person = await _personServices.GetByIdAsync(id, cancellationToken);
        var response = _mapper.Map<GetPersonByIdResponse>(person);
        return response;
    }

    /// <summary>
    /// Обновление Person
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task UpdatePersonResponse</returns>
    public async Task<UpdatePersonResponse> UpdateAsync(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        var updatedPerson = await _personServices.UpdateAsync(person, cancellationToken);
        var response = _mapper.Map<UpdatePersonResponse>(updatedPerson);
        return response;
    }

    /// <summary>
    /// Удаление Person по идентификатору
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns> Task DeletePersonResponse</returns>
    public async Task<DeletePersonResponse> DeleteByIdAsync(DeletePersonRequest request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        var isDeleted = await _personServices.DeleteByIdAsync(person.Id, cancellationToken);
        var response = _mapper.Map<DeletePersonResponse>(isDeleted);
        return response;
    }
}