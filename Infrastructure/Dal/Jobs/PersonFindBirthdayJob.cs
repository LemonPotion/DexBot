using Application.Interfaces.Repositories;
using Quartz;

namespace Infrastructure.Dal.Jobs;

public class PersonFindBirthdayJob : IJob
{
    private readonly IPersonRepository _personRepository;
    
    public PersonFindBirthdayJob(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    public async Task Execute(IJobExecutionContext context)
    {
        var cancellationToken = context.CancellationToken;
    
        var persons = await _personRepository.GetAllListAsync(cancellationToken);
        Console.WriteLine("Today birthdays:");
        foreach (var person in persons.Where(person => person.BirthDay.Date == DateTime.Today))
        {
            Console.WriteLine($"{person.FullName.FirstName} {person.FullName.LastName}");
        }
        
    }
}