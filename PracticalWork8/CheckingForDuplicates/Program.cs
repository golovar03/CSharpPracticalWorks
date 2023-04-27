using System.Linq;

namespace CheckingForDuplicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> Myset = new HashSet<int>();
            Console.WriteLine("Вводите числа. После ввода каждого числа, нажмите 'Enter'");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape) 
            {
                Console.Write("Число: ");
                string value = Console.ReadLine();
                if (!String.IsNullOrEmpty(value) & Int32.TryParse(value, out _))
                {
                    if (!Myset.Contains(Convert.ToInt32(value)))
                    {
                        Myset.Add(Convert.ToInt32(value));
                        Console.WriteLine($"Число {value} успешно добавлено в коллекцию!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"Число {value} уже присутствует в коллекции!");
                    }
                }
                else
                {
                    Console.WriteLine("Введеное значение пустое или не является целым числом!");
                    continue;
                }
                
            }
            
        }
    }
}