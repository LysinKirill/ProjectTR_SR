using System.Text;
using EKRLib;

public class Program
{
    public static void Main(string[] args)
    {
        
        char inputChar = ' ';

        // Цикл повтора решения
        while (inputChar != '0')
        {
            // создание списка транспортных средств
            List<Transport> vehicles = GenerateTransportData(6, 10);

            
            // Если программа (цикл) исполняется несколько раз, то в файлы сохраняются только транспортные средства, сгенерированные при последнем исполнении

            // Отбор из списка элементов типа Motorboat и их запись в файл MotorBoats.txt
            WriteInfo(@"../../../../MotorBoats.txt", vehicles.Where(x => x is Motorboat).Select(x => x.ToString()).ToArray());
            
            // Отбор из списка элементов типа Car и их запись в файл Cars.txt
            WriteInfo(@"../../../../Cars.txt", vehicles.Where(x => x is Car).Select(x => x.ToString()).ToArray());
            
            
            Console.WriteLine("Данные об автомобилях и моторных лодках записаны в файлы Cars.txt и MotorBoats.txt соответственно\n" +
                              "__________________________________________________________________\n" + 
                              "Для завершения работы программы нажмите 0\n" +
                              "Для повтора программы нажмите любую другую клавишу.");
            
            inputChar = Console.ReadKey().KeyChar;
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Генерирует список транспортных средств случайной длины от left до right (левая граница включается, а правая не включается)
    /// </summary>
    /// <param name="left">Минимальное количество элементов, которые должны содержаться в списке</param>
    /// <param name="right">Максимальное количесвто элементов (не включительно)</param>
    /// <returns>Список объектов типа Transport</returns>
    static List<Transport> GenerateTransportData(int left, int right)
    {
        Random random = new Random();
        List<Transport> vehicles = new List<Transport>();
        int n = random.Next(left, right);

        while (vehicles.Count < n)
        {
            // Блок обработки исключений, которые могут возникнуть при создании транспортного средства
            try
            {
                // Добавление в список транспортных средств сгенерированного объекта типа Car или Motorboat
                vehicles.Add(
                    random.NextDouble() < 0.5d
                        ? new Car(Transport.GetRandomModel(), (uint)random.Next(10, 100))
                        : new Motorboat(Transport.GetRandomModel(), (uint)random.Next(10, 100))
                );
                // Вывод в консоль звука транспортного средства, добавленного в список
                Console.WriteLine(vehicles[^1].StartEngine());
            }
            catch (TransportException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return vehicles;
    }
    
    /// <summary>
    /// Метод, производящий запись строк из массива data в файл по указанному пути
    /// </summary>
    /// <param name="path">Путь, по которому происходит сохраниние данных в файл</param>
    /// <param name="data">Произвольное число строк или массив строк, которые подлежат записи в файл</param>
    static void WriteInfo(string path, params string[] data)
    {
        try
        {
            // Запись данных в файл в кодировке utf-16 (Unicode)
            using(StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode))
            {
                foreach (string line in data)
                {
                    sw.WriteLine(line);
                }
            }
        }
        // Обрабатывается сразу самое общее исключение потому что от программа не требует вариативности действий для различных видов исключений
        catch
        {
            Console.WriteLine("Не удалось записать данные по заданному пути/имени файла");
        }
    }
}