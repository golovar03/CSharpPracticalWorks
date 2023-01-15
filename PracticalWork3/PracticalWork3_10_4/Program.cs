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

            int minNumber = int.MaxValue;
            while (true)
            {
                Console.Write("Введите длину последовательности чисел: ");
                string userSequenceLength = Console.ReadLine();

                if ((int.TryParse(userSequenceLength, out int sequenceLength)) && (sequenceLength > 0))
                {
                    Console.WriteLine($"Теперь введите {sequenceLength} целых чисел. Разделяйте ввод клавишей Enter");
                    int i = 1;
                    while (i <= sequenceLength)
                    {
                        Console.Write($"{i}-ое число последовательности: ");
                        string userNumber = Console.ReadLine();

                        if (int.TryParse(userNumber, out int convertedUserNumber))
                        {
                            if (convertedUserNumber < minNumber)
                                minNumber = convertedUserNumber;
                            i++;
                        }
                        else
                        {
                            Console.WriteLine("Вы вели не целое число. Введите корректное число!");
                        }
                    }

                    Console.WriteLine($"Минимальное число в последовательности из {sequenceLength} элементов:" +
                        $" {minNumber}");
                }
                else
                {
                    Console.WriteLine("Введите целое положительное число отличное от 0");
                    continue;
                }
                break;
            }
            Console.ReadKey();
        }
    }
}
