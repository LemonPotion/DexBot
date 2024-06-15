using System.Text.RegularExpressions;

namespace Domain.Validations;
/// <summary>
/// Класс хранящи Regex паттерны 
/// </summary>
public class RegexPatterns
{
    /// <summary>
    /// Паттерн номера телефона
    /// </summary>
    public static readonly Regex Phone= new(@"^\+?\d{9,15}$");
    /// <summary>
    /// Паттерн ника в Telegram
    /// </summary>
    public static readonly Regex TelegramName = new("^@[A-Za-z0-9_]+$");
    /// <summary>
    /// Паттерн полного имени 
    /// </summary>
    public static readonly Regex FullName = new(@"^[a-zA-Zа-яА-Я0-9']+$");
}