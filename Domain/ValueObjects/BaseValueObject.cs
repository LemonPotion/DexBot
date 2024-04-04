using System.Text.Json;
namespace Domain.ValueObjects
{
    ///TODO: как сравнивать эти объекты (DeepClone, DeepComparse)
    public abstract class BaseValueObject
    {
        public override bool Equals(object? obj)
        {
            if (obj is not BaseValueObject valueObject)
                return false;
            var serializedValueObject = Serialize(valueObject);
            var serializedThis = Serialize(this);
            
            if (string.CompareOrdinal(serializedValueObject, serializedThis) != 0) 
                return false;
                
            return true;
        }
        
        public override int GetHashCode()
        {
            return Serialize(this).GetHashCode();
        }

        /// <summary>
        /// Метод для сериализации обьектов BaseValueObject
        /// </summary>
        /// <param name="valueObject"></param>
        /// <returns></returns>
        public string Serialize(BaseValueObject valueObject)
        {
            var serializedValueObject = JsonSerializer.Serialize(valueObject);
            return serializedValueObject;
        }
    }
}
