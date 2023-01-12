using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork3_10_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите целое число и скажу 'четное оно или нет:' ");
            int number = int.Parse(Console.ReadLine());

            if (number % 2 == 0)
            {
                Console.WriteLine($"Веденное число {number} является четным");
            }
            else
            {
                Console.WriteLine($"Веденное число {number} является нечетным");
            }
            Console.ReadKey();
        }
    }
}
