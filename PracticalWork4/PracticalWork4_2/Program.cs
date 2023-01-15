using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork4_2
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
                    Console.WriteLine($"Генерирую Матрицу А {numberOfLines} на {numberOfColumns}:\n");
                    int[,] matrixA = new int[numberOfLines, numberOfColumns];
                    Console.WriteLine($"Генерирую Матрицу B {numberOfLines} на {numberOfColumns}:\n");
                    int[,] matrixB = new int[numberOfLines, numberOfColumns];
                    int[,] matrixC = new int[numberOfLines, numberOfColumns];
                    Random randomNumber = new Random();
                    for (int i = 0; i < numberOfLines; i++)
                    {
                        for (int j = 0; j < numberOfColumns; j++)
                        {
                            matrixA[i, j] = randomNumber.Next(-9, 10);
                            matrixB[i, j] = randomNumber.Next(-9, 10);
                            matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                        }
                    }
                    int index = 0;
                    Console.WriteLine("Матрицы готовы. Вывожу:");
                    Console.WriteLine("Матрица А:");
                    foreach (int e in matrixA)
                    {
                        Console.Write($"{e,3} ");
                        index++;
                        if (index % numberOfColumns == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Матрица B:");
                    foreach (int e in matrixB)
                    {
                        Console.Write($"{e,3} ");
                        index++;
                        if (index % numberOfColumns == 0)
                        {
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Матрица C (сумма матриц А и В):");
                    foreach (int e in matrixC)
                    {
                        Console.Write($"{e,3} ");
                        index++;
                        if (index % numberOfColumns == 0)
                        {
                            Console.WriteLine();
                        }
                    }
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
