using Quartz;

namespace Infrastructure.Dal.Jobs;
//TODO: сделать джобу которая получает все сегодняшние др и выводит их в консоль

public class Job : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("11123");
        return Task.CompletedTask;
    }
}