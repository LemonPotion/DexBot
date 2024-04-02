using System.Text.RegularExpressions;

namespace Domain.Validations;

public class RegexPatterns
{
    /// <summary>
    /// Паттерн номера телефона
    /// </summary>
    public static readonly Regex Phone= new(@"\+373[4,9]\d{5}$");
    /// <summary>
    /// Паттерн ника в Telegram
    /// </summary>
    public static readonly Regex TelegramName = new("^@[A-Za-z0-9_]$");
    /// <summary>
    /// Паттерн полного имени 
    /// </summary>
    public static readonly Regex FullName = new(@"^[a-zA-Zа-яА-Я0-9']+$");
}