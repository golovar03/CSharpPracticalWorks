using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PracticalWork7_8
{
    internal class Program
    {
        static private string codeOfOperation = "waitCode";
        static readonly string path = @"base.csv";
        static Repository reposit = new Repository(path);
        static void Main(string[] args)
        {
            
            while (codeOfOperation != "0")
            {
                Console.WriteLine("\n0 - Выход, 1: Добавить сотрудника, 2: Вывести все записи, 3: Поиск сотрудника, 4: Удалить запись по ID\n");
                Console.Write("Введите команду: ");
                codeOfOperation = Console.ReadLine();
                bool success = int.TryParse(codeOfOperation, out _);
                if (success)
                {
                    switch (Convert.ToInt32(codeOfOperation))
                    {
                        case 0:
                            Console.WriteLine("Работа с приложением завершена");
                            break;
                        case 1:
                            Console.WriteLine("Добавить сотрудника:");
                            CreateWorkwer();
                            break;
                        case 2:
                            Console.WriteLine("Вывести все записи: ");
                            reposit.PrintAllWorkers(path);
                            break;
                        case 3:
                            SearchWorker();
                            break;
                        default:
                            Console.WriteLine("Такой команды нет");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка ввода команды!");
                }
            }
            Console.ReadKey();
        }
        static void CreateWorkwer()
        {
            string newID = Guid.NewGuid().ToString();
            Console.Write("ФИО сотрудника: ");
            string fullName = Console.ReadLine();
            Console.Write("Дата рождения: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            byte age = Convert.ToByte(Convert.ToInt64((DateTime.Now.Date - dateOfBirth.Date).TotalDays) / 365);
            Console.WriteLine($"Возраст: {age}");
            Worker worker = new Worker(newID, fullName, dateOfBirth, age);
            reposit.Add(worker);
        }

        static void SearchWorker()
        {
            Console.WriteLine("Поиск по полю: 1- ID, 2- ФИО, 3- Дата рождения ");
            Console.Write("Код поля: ");
            codeOfOperation = Console.ReadLine();
            bool success = int.TryParse(codeOfOperation, out _);
            if (success)
            {
                switch (Convert.ToInt32(codeOfOperation))
                {
                    case 0:
                        Console.WriteLine("В главное меню");
                        break;
                    case 1:
                        Console.WriteLine("Ищем по ID");
                        //CreateWorkwer();
                        break;
                    case 2:
                        Console.WriteLine("Ищем по ФИО ");
                        string name = Console.ReadLine();
                        reposit.SearchWorker(path, name);
                        break;
                    case 3:
                        Console.WriteLine("Ищем по дате рождения");
                        break;
                    default:
                        Console.WriteLine("Такой команды нет");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ошибка ввода команды!");
            }
        }
    }
}
