using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork3_10_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int checkNumber;
            bool numberIsSimple = true;
            Console.WriteLine("Программа проверяет: является ли введеное число простым");
            Console.Write("Введите число, которое хотите проверить: ");
            checkNumber = int.Parse(Console.ReadLine());
            
            if (checkNumber < 1)
            {
                Console.WriteLine($"Число {checkNumber} не подойдет. Введите целое положительное число," +
                   $"которое больше 1");
            }
            else 
            {
                int range = checkNumber - 1;
                while (range > 1)
                {
                    if (checkNumber % range == 0)
                    {
                        numberIsSimple = false;
                        break;
                    }
                    range--;
                }

                if (numberIsSimple == true)
                {
                    Console.WriteLine($"Число {checkNumber} простое");
                }
                else
                {
                    Console.WriteLine($"Число {checkNumber} составное");
                }
            }
            Console.ReadKey();
        }
    }
}
