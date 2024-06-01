using Quartz;

namespace Infrastructure.Dal.Jobs;
public class Job : IJob
{
    public Task Execute(IJobExecutionContext context)
    {
        Console.WriteLine("11123");
        return Task.CompletedTask;
    }
}