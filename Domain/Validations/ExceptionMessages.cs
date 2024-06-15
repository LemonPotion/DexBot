namespace Domain.Validations;

/// <summary>
/// Класс содержащий сообщения об ошибках
/// Используйте string.Format() для вызова сообщений
/// </summary>
public abstract class ExceptionMessages
{
    /// <summary>
    /// Сообщение null исключения
    /// </summary>
    public const string NullError = "{0} is null";
    /// <summary>
    /// Сообщение empty исключения
    /// </summary>
    public const string EmptyError = "{0} is empty";
    /// <summary>
    /// Сообщение старой даты
    /// </summary>
    public const string OldDateError = "{0} Date is too old";
    /// <summary>
    /// Сообщение будущей даты
    /// </summary>
    public const string FutureDateError = "{0} Date is future";
    /// <summary>
    /// Сообщение о неверной формате ника в телеграм
    /// </summary>
    public const string InvalidTelegramNameFormat = "{0} Telegram nickname is incorrect format";
    /// <summary>
    /// Сообщение о неверном формате номера телефона 
    /// </summary>
    public const string InvalidPhoneFormat = "{0} Phone number invalid format ";

    /// <summary>
    /// Сообщение о неверном формате имени
    /// </summary>
    public const string InvalidNameFormat = "{0} Name is invalid format";

    /// <summary>
    /// Сообщение о ошибке перечисления
    /// </summary>
    public const string DefaultEnum = "Enum {0} can't be default";
    /// <summary>
    /// Сообщение о ошибке значения перечисления
    /// </summary>
    public const string InvalidEnumValue = "{0} Invalid enum value";
}