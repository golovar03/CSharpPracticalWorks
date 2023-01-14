using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork3_10_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину последовательности чисел: ");
            int sequenceLength = int.Parse(Console.ReadLine());
            int minNumber = int.MaxValue;
            if (sequenceLength > 0)
            {
                Console.WriteLine($"Теперь введите {sequenceLength} целых чисел. Разделяйте ввод клавишей Enter");
                for (int i = 1; i <= sequenceLength; i++)
                {
                    Console.Write($"{i}-ое число последовательности: ");
                    int userNumber = int.Parse(Console.ReadLine());
                    if (userNumber < minNumber)
                    {
                        minNumber = userNumber;
                    }
                }
                Console.WriteLine($"Минимальное число в последовательности из {sequenceLength} элементов:" +
                    $" {minNumber}");
            }
            else 
            {
                Console.WriteLine("Введите целое положительное число отличное от 0");
            }
            Console.ReadKey();
        }
    }
}
