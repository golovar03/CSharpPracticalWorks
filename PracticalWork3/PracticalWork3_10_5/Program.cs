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


            while (true)
            {
                Console.Write($"\nУкажи размер игрового поля (хотя бы от 50)" +
                    $"\nЧтобы заночить игру, оставь поле пустым и нажми \"Enter\"" +
                    $"\nРазмер поля:");
                string userFieldSize = Console.ReadLine();

                if (!String.IsNullOrEmpty(userFieldSize))
                {
                    if (int.TryParse(userFieldSize, out int playingFieldSize))
                    {
                        Console.WriteLine($"Я загадал число от 0 до {playingFieldSize}. " +
                            $"Теперь попробуй отгадать его.\nЧтобы сдаться, ничего не вводи " +
                            $"и просто нажми: \"Enter\"");
                        int hiddenNumber = randomNumber.Next(0, playingFieldSize + 1);
                        while (true)
                        {
                            Console.Write($"\nТвой ответ?: ");
                            string inputUserNumber = Console.ReadLine();

                            if (!String.IsNullOrEmpty(inputUserNumber))
                            {
                                if (int.TryParse(inputUserNumber, out int userNumber))
                                {
                                    userNumber = int.Parse(inputUserNumber);
                                    if (userNumber == hiddenNumber)
                                    {
                                        Console.WriteLine($"Поразительно! Я действительно загадал {hiddenNumber}");
                                        Console.ReadKey();
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
                                    Console.WriteLine($"Нет. Введи целое число от 0 до {playingFieldSize}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"\nСалага. Я загадал {hiddenNumber}");
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Размер поля нужно указать в виде целого числа. Попробуй еще раз.");
                    }
                }
                else
                {
                    Console.WriteLine("Ты указал пустое игровое поле. Игра окончена");
                    Console.ReadKey();
                    break;
                    ;
                }
            }
        }
    }
}
