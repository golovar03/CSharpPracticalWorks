using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PracticalWork3_10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Как тебя зовут? Имя: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Привет, {userName}! Сыграем в двадцать одно?" +
                $"Возьми карты со стола и напиши мне сколько ты взял карт.");
            Console.Write("Взять карт: ");
            int totalNominalOfUserCards = 0;
            while (true)
            {
                string inputOfUserCards = Console.ReadLine();
                if (int.TryParse(inputOfUserCards, out int numberOfUserCards))
                {
                    Console.WriteLine($"\nОтлично. У тебя на руках {numberOfUserCards} шт. карт. Я тоже возьму несколько.\n");
                    Console.WriteLine($"А теперь вскрываемся! Напиши, какие ты карты взял. А я тебе помогу:\n" +
                    $" карты без картинок: от 6 до 10\n Валет: J или j\n Дама: Q или q\n" +
                    $" Король: K или k\n Туз: T или t");

                    for (int i = 1; i <= numberOfUserCards; i++)
                    {
                        Console.Write($"Введи номинал {i}-ой карты: ");
                        string nominalOfUserCard = Console.ReadLine().ToUpper();

                        switch (nominalOfUserCard)
                        {
                            case "J":
                                nominalOfUserCard = "10"; break;
                            case "Q":
                                nominalOfUserCard = "10"; break;
                            case "K":
                                nominalOfUserCard = "10"; break;
                            case "T":
                                nominalOfUserCard = "10"; break;
                            case "6":
                                nominalOfUserCard = "6"; break;
                            case "7":
                                nominalOfUserCard = "7"; break;
                            case "8":
                                nominalOfUserCard = "8"; break;
                            case "9":
                                nominalOfUserCard = "9"; break;
                            case "10":
                                nominalOfUserCard = "10"; break;
                            default:
                                Console.WriteLine("Такой карты не существует");
                                i--;
                                continue;
                        }
                        totalNominalOfUserCards = totalNominalOfUserCards + int.Parse(nominalOfUserCard);
                    }
                }
                else
                {
                    Console.WriteLine("Возьми хоть одну карту!");
                    continue;
                }
                break;
            }

            Random randomNominal = new Random();
            int totalNominalOfAICards = randomNominal.Next(6, 21);
            string gameMessage;

            if ((totalNominalOfUserCards <= 21) && (totalNominalOfUserCards >= 6) &&
                (totalNominalOfUserCards >= totalNominalOfAICards))
            {
                gameMessage = "Ты победил";
            }
            else if (((totalNominalOfUserCards > 21) && (totalNominalOfAICards <= 21)) ||
                ((totalNominalOfUserCards < 21 && totalNominalOfUserCards >= 6) && (totalNominalOfAICards <= 21) &&
                (totalNominalOfAICards > totalNominalOfUserCards)))
            {
                gameMessage = "Я тебя сделал! :)";
            }
            else if ((totalNominalOfUserCards > 21) && (totalNominalOfAICards > 21))
            {
                gameMessage = "У меня перебор. У тебя, похоже, тоже!";
            }
            else
            {
                gameMessage = "Попахивает мухлежом!";
            }

            Console.WriteLine($"{userName}, ты набрал {totalNominalOfUserCards} очков. " +
                $"У меня {totalNominalOfAICards} очков! {gameMessage}");
            Console.ReadKey();
        }
    }
}
