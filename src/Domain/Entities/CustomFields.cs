namespace Domain.Entities;

/// <summary>
/// Класс пользовательских полей
/// </summary>
/// <typeparam name="TType"></typeparam>
public class CustomFields<TType> : BaseEntity
{
    /// <summary>
    /// Имя поля (Название)
    /// </summary>
    public string Name  { get; set; }
    
    /// <summary>
    /// Значение
    /// </summary>
    public TType Value { get; set; }
    
    /// <summary>
    /// Id 
    /// </summary>
    public Guid PersonId { get; set; }
}