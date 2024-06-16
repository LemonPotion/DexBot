namespace Infrastructure.Settings;

public class OpenAISettings
{
    public string ApiKey { get; set; }
    public string Prompt { get; set; }
    public int MaxTokens { get; set; }
    public string Model { get; set; } 
    public double Temperature { get; set; }
    public double TopP { get; set; }
    public int N { get; set; }
    public string Stop { get; set; }
    public double PresencePenalty { get; set; }
    public double FrequencyPenalty { get; set; }
}