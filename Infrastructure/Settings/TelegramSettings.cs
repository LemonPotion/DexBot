namespace Infrastructure.Settings;
/// <summary>
/// Telegram bot settings
/// </summary>
public class TelegramSettings
{
    public string BotToken { get; set; }
    public string ChatId { get; set; }
    
    public string ImageUri { get; set; }
}