using Application.Interfaces.Repositories;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Quartz;
using Telegram.Bot;
using InputFile = Telegram.Bot.Types.InputFile;

namespace Infrastructure.Jobs;
/// <summary>
/// Job that sends birthday congratulation messages to persons 
/// </summary>
public class PersonFindBirthdayJob : IJob
{
    private readonly IPersonRepository _personRepository;
    private readonly TelegramSettings _telegramSettings;
    private readonly TelegramBotClient _telegramBotClient;
    
    public PersonFindBirthdayJob(IPersonRepository personRepository, IOptions<TelegramSettings> telegramSettings)
    {
        _personRepository = personRepository;
        _telegramSettings = telegramSettings.Value;
        _telegramBotClient = new TelegramBotClient(_telegramSettings.BotToken);
    }
    
    public async Task Execute(IJobExecutionContext context)
    {
        var cancellationToken = context.CancellationToken;
        await SendMessageAsync(DateTime.Now.ToString(), cancellationToken);
    }
    /// <summary>
    /// Send message to telegram with photo 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="cancellationToken"></param>
    private async Task SendMessageAsync(string message, CancellationToken cancellationToken)
    {
        try
        {
            var persons = await _personRepository.GetBirthdayPersonsAsync(DateTime.Now, cancellationToken);
            foreach (var person in persons)
            {
                await _telegramBotClient.SendPhotoAsync(chatId: _telegramSettings.ChatId,
                    photo: InputFile.FromUri("https://preview.redd.it/binfjjnfxan61.jpg?width=640&crop=smart&auto=webp&s=38bd5f1af64330e227517d60dabb50bfe09550c4"), 
                    caption: message, 
                    cancellationToken: cancellationToken);
                
                await _telegramBotClient.SendTextMessageAsync(_telegramSettings.ChatId, message, cancellationToken: cancellationToken);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error sending message : {e.Message}");
            throw;
        }
    }
}