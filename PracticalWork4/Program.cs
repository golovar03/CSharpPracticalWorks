using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Матрица случайных чисел.");
            while (true)
            {
                Console.Write("Введите количество строк: ");
                int.TryParse(Console.ReadLine(), out int numberOfLines);
                Console.Write("Введите количество столбцов: ");
                int.TryParse(Console.ReadLine(), out int numberOfColumns);
                if (numberOfLines != 0 && numberOfColumns != 0)
                {
                    Console.WriteLine($"Генерирую массив {numberOfLines} на {numberOfColumns}:\n");
                    int[,] arrayOfNumbers = new int[numberOfLines, numberOfColumns];
                    Random randomNumber = new Random();
                    int summAllNumbers = 0;
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        for (int j = 0; j < numberOfColumns; j++)
                        {
                            arrayOfNumbers[i, j] = randomNumber.Next(-9, 10);
                            summAllNumbers += arrayOfNumbers[i, j];
                            Console.Write($" {arrayOfNumbers[i, j],2} ");
                        }
                        Console.WriteLine();
                    }
                    Console.Write($"\nСумма всех элементов двумерного массива размерностью {numberOfLines} на {numberOfColumns}\n" +
                        $"равна: {summAllNumbers}");
                    break;
                }
                else
                {
                    Console.WriteLine($"Ошибка. Вы ввели неправильно одно из двух значений. Пожалуйста, повторите ввод данных.\n");
                    continue;
                }
            }
            Console.ReadKey();
        }
    }
}
