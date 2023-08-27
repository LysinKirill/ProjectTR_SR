namespace EKRLib;

/// <summary>
/// Класс, представляющий объекты автомобилей. Наследник абстрактного класса Transport
/// </summary>
public class Car : Transport
{
    public Car(string model, uint power) : base(model, power)
    {
    }

    /// <summary>
    /// Метод, возвращающий звук, издаваемый автомобилем
    /// </summary>
    /// <returns></returns>
    public override string StartEngine() => $"{Model}: Vroom";
    
    public override string ToString()
    {
        return "Car. " + base.ToString();
    }
}