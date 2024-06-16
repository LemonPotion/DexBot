using Application.Interfaces.Repositories;
using Application.Services;
using Infrastructure.Dal.EntityFramework;
using Infrastructure.Dal.Repositories;
using Infrastructure.Jobs;
using Infrastructure.Settings;
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

        var cron = builder.Services.Configure<CronExpressionSettings>(builder.Configuration.GetSection(nameof(CronExpressionSettings)));
        builder.Services.Configure<TelegramSettings>(builder.Configuration.GetSection(nameof(TelegramSettings))); 
        builder.Services.Configure<QuartzOptions>(builder.Configuration.GetSection("Quartz"));
        builder.Services.Configure<OpenAISettings>(builder.Configuration.GetSection(nameof(OpenAISettings)));
        
        builder.Services.AddQuartz(config =>
        {
            var cronExpressionSettings =builder.Configuration.GetSection(nameof(CronExpressionSettings)).Get<CronExpressionSettings>();
            config.UseSimpleTypeLoader();
            config.UseInMemoryStore();
            
            var birthdayJobKey = new JobKey("personFindBirthdayJob");
            
            config.AddJob<PersonFindBirthdayJob>(opts => opts.WithIdentity(birthdayJobKey)
                    .WithDescription("Finds persons with today's birthdate"));
            
            var birthdayTriggerKey = new TriggerKey("personFindBirthdayJobTrigger");
            
            config.AddTrigger(opts=> opts.ForJob(birthdayJobKey)
                .WithIdentity(birthdayTriggerKey)
                .WithCronSchedule(cronExpressionSettings.PersonFindBirthdayJob));
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
