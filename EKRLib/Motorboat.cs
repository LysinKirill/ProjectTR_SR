namespace EKRLib;

/// <summary>
/// Класс, представляющий объекты моторных лодок. Наследник абстрактного класса Transport
/// </summary>
public class Motorboat : Transport
{
    public Motorboat(string model, uint power) : base(model, power)
    {
    }

    /// <summary>
    /// Метод, возвращающий звук, издаваемый моторной лодкой
    /// </summary>
    /// <returns></returns>
    public override string StartEngine() => $"{Model}: Brrrbrr";
    
    public override string ToString()
    {
        return "MotorBoat. " + base.ToString();
    }
}