namespace EKRLib;

public abstract class Transport
{
    private string? _model;
    private uint _power;
    
    public string? Model
    {
        get => _model;

        private set
        {
            // Проверка модели на соответствие спецификации
            if (value == null || value.Length != 5)
                throw new TransportException($"Недопустимая модель {value}");
            
            foreach (char c in value)
            {
                if(!((c >= 'A' && c <= 'Z') || (c >= '0' && c <= '9')))
                    throw new TransportException($"Недопустимая модель {value}");
            }

            _model = value;
        }
    }

    public uint Power
    {
        get => _power;

        private set
        {
            if (value < 20)
                throw new TransportException("мощность не может быть меньше 20 л.с.");
            _power = value;
        }
    }
    
    /// <summary>
    /// Параметрический конструктор, принимающий два аргумента и возвращающий ссылку на объект типа Transport
    /// </summary>
    /// <param name="model">строка, представляющая модель транспортного средства</param>
    /// <param name="power">неотрицательное число, представляющее мощность транспортного средства в лошадиных силах</param>
    public Transport(string model, uint power)
    {
        Model = model;
        Power = power;
    }

    /// <summary>
    /// Генерирует строковое представление случайной модели, удовлетворяющей спецификации
    /// </summary>
    /// <returns>случайная модель транспорта</returns>
    public static string GetRandomModel()
    {
        // Можно было воспользоваться StringBuilder, но происходит всего 5 конкатенаций, т.ч. потеря по времени некритична
        string validSymbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        string model = String.Empty;
        Random rand = new Random();

        for (int i = 0; i < 5; i++)
            model += validSymbols[rand.Next(0, validSymbols.Length)];
        return model;
    }
    
    /// <summary>
    /// Метод, позволяющий получить звук, издаваемый транспортом
    /// </summary>
    /// <returns>строковое представление звука, издаваемого транспортом</returns>
    public abstract string StartEngine();

    public override string ToString()
    {
        return $"Model: {Model}, Power: {Power}";
    }
}