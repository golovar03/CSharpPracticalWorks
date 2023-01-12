using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork3_10_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random randomNumber = new Random();
            Console.WriteLine($"Игра \"Угадай число\"");
            Console.WriteLine($"Укажи размер игрового поля (хотя бы от 50): ");
            string userFieldSize = Console.ReadLine();
            if (userFieldSize != "")
            { 
            int playingFieldSize = int.Parse(userFieldSize);
            Console.WriteLine($"Я загадал число от 0 до {playingFieldSize}. " +
                $"Теперь попробуй отгадать его. \nЧтобы сдаться, ничего не вводи " +
                $"и просто нажми: \"Enter\"");
            int hiddenNumber = randomNumber.Next(0,playingFieldSize+1);
                while (true)
                {
                    Console.Write($"Твой ответ?: ");
                    string inputUserNumber = Console.ReadLine();
                    if (inputUserNumber != "")
                    {
                        int userNumber = int.Parse(inputUserNumber);
                        if (userNumber == hiddenNumber)
                        {
                            Console.WriteLine($"Поразительно! Я действительно загадал {hiddenNumber}");
                            break;
                        }
                        else if (userNumber < hiddenNumber)
                        {
                            Console.WriteLine($"Нет! Я загадал число больше. Попробуй еще раз");
                        }
                        else
                        {
                            Console.WriteLine($"Нет! Я загадал число меньше. Попробуй еще раз");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Салага. Я загадал {hiddenNumber}");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Ты указал пустое игровое поле.");
            }
            Console.ReadKey();
        }
    }
}
