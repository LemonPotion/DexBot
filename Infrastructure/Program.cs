using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Jobs;
using Infrastructure.Dal.Repositories;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace Infrastructure;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen();
        
        var cronExpressionSettings = builder.Configuration.GetSection("CronExpression").Get<CronExpressionSettings>();
        
        builder.Services.AddQuartz(config =>
        {
            //TODO: найти альтернативы  
            config.UseMicrosoftDependencyInjectionJobFactory();
            
            var jobKey = new JobKey("personFindBirthdayJob");
            config.AddJob<PersonFindBirthdayJob>(opts => opts.WithIdentity(jobKey));
            var triggerKey = new TriggerKey("personFindBirthdayJobTrigger");
            
            config.AddTrigger(opts=> opts.ForJob(jobKey).WithIdentity(triggerKey).WithCronSchedule(cronExpressionSettings.PersonFindBirthdayJob));
        });

        builder.Services.AddQuartzHostedService(opts =>
        {
            opts.WaitForJobsToComplete= true;
        });
        
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        
        builder.Services.AddScoped<IPersonRepository, PersonRepository>();
        builder.Services.AddScoped<PersonService>();
        
        builder.Services.AddDbContext<DexBotDbContext>
            (options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}