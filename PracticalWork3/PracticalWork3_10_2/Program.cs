using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
Игра 21 ("Очко") Номиналы карт соответствуют общепринятым правилам игры: Туз - 11 очков, Король - 4 очка,
Дама - 3 очка, Валет - 2, далее карты по номиналу. Используется колода 36 карт: номиналы от 6 до Туза
 */
namespace PracticalWork3_10_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfUserCards;
            string nominalofUserCard;
            Random randomNominal= new Random();
            string gameMessage;
            
            Console.Write("Как тебя зовут? Имя: ");
            string userName = Console.ReadLine();
            Console.WriteLine($"Привет, {userName}! Сыграем в двадцать одно?" +
                $"Возьми карты со стола и напиши мне сколько ты взял карт.");
        Start:
            Console.Write("Взять карт: ");
            numberOfUserCards = int.Parse(Console.ReadLine());
            int totalNominalOfUserCards = 0;
            if (numberOfUserCards >= 1)
            {
                Console.WriteLine($"\nОтлично. У тебя на руках {numberOfUserCards} шт. карт. Я тоже возьму несколько.");
                Console.ReadLine();
                Console.WriteLine($"А теперь вскрываемся! Напиши, какие ты карты взял. А я тебе помогу:\n" +
                $" карты без картинок: от 6 до 10\n Валет: J или j\n Дама: Q или q\n" +
                $" Король: K или k\n Туз: T или t");
           
                for (int i = 1; i <= numberOfUserCards; i++)
                {
                    Console.Write($"Введи номинал {i}-ой карты: ");
                    nominalofUserCard = Console.ReadLine().ToUpper();

                    switch (nominalofUserCard)
                    {
                        case "J":
                            nominalofUserCard = "2"; break;
                        case "Q":
                            nominalofUserCard = "3"; break;
                        case "K":
                            nominalofUserCard = "4"; break;
                        case "T":
                            nominalofUserCard = "11"; break;
                        case "6":
                            nominalofUserCard = "6"; break;
                        case "7":
                            nominalofUserCard = "7"; break;
                        case "8":
                            nominalofUserCard = "8"; break;
                        case "9":
                            nominalofUserCard = "9"; break;
                        case "10":
                            nominalofUserCard = "10"; break;
                        default:
                            Console.WriteLine("Такой карты не существует");
                            continue;
                    }
                    totalNominalOfUserCards = totalNominalOfUserCards + int.Parse(nominalofUserCard);
                }
            }
            else
            {
                Console.WriteLine("Возьми хоть одну карту!");
                goto Start;
            }

            int totalNominalOfAICards = randomNominal.Next(6, 33);
            
            if ((totalNominalOfUserCards <= 21)&&(totalNominalOfUserCards>=2)&&
                (totalNominalOfUserCards>=totalNominalOfAICards))
            {
                gameMessage = "Ты победил"; 
            }
            else if ((totalNominalOfUserCards<totalNominalOfAICards)&&
                (totalNominalOfUserCards>=2)&&(totalNominalOfAICards<=21))
            {
                gameMessage = "Я тебя сделал! :)";
            }
            else if ((totalNominalOfUserCards>21)&&(totalNominalOfAICards>21))
            {
                gameMessage = "У меня перебор. У тебя, похоже, тоже!";
            }
            else
            {
                gameMessage = "Попахивает мухлежом!";
            }
            
            Console.WriteLine($"{userName}, ты набрал {totalNominalOfUserCards} очков. " +
                $"У меня {totalNominalOfAICards} очков! {gameMessage}");
            Console.WriteLine("Еще разок? ;) Enter - да, ESC или любая другая клавиша - нет");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                goto Start;
            }
            else
            {
                Console.ReadKey();
            } 
        }
    }
}
