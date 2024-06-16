using Application.Dto_s.Person.Requests;
using Application.Dto_s.Person.Responses;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services;
public class PersonService
{
    
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    
    public PersonService(IMapper mapper, IPersonRepository personRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
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
        var createdPerson = await _personRepository.CreateAsync(person, cancellationToken);
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
        var person = await _personRepository.GetByIdAsync(id, cancellationToken);
        var response = _mapper.Map<GetPersonByIdResponse>(person);
        return response;
    }
    /// <summary>
    /// Получить список всех Person
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<List<GetPersonByIdResponse>> GetAll(CancellationToken cancellationToken)
    {
        var persons = await _personRepository.GetAllListAsync(cancellationToken);
        return _mapper.Map<List<GetPersonByIdResponse>>(persons);
    }

    /// <summary>
    /// Обновление Person
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>Task UpdatePersonResponse</returns>
    public async Task<UpdatePersonResponse> UpdateAsync(UpdatePersonRequest request, CancellationToken cancellationToken)
    {
        var updateRequest = _mapper.Map<Person>(request); 
        var updatedPerson = _personRepository.UpdateAsync(updateRequest,cancellationToken);
        
        var getPersonByIdResponse = await GetByIdAsync(request.Id, cancellationToken);
        var person = _mapper.Map<Person>(getPersonByIdResponse);
        
        var updatePersonResponse = _mapper.Map<UpdatePersonResponse>(person);
        return updatePersonResponse;
    }

    /// <summary>
    /// Удаление Person по идентификатору
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns> Task DeletePersonResponse</returns>
    public async Task<bool> DeleteByIdAsync(DeletePersonRequest request, CancellationToken cancellationToken)
    {
        var person = _mapper.Map<Person>(request);
        var isDeleted = await _personRepository.DeleteByIdAsync(person.Id, cancellationToken);
        return isDeleted;
    }
}