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
        static private string _codeOfOperation = "waitCode";
        static readonly string path = @"base.csv";
        static Repository reposit = new Repository(path);
        static void Main(string[] args)
        {
            
            while (_codeOfOperation != "0")
            {
                Console.WriteLine("\n0 - Выход, 1: Добавить сотрудника, 2: Вывести все записи, 3: Поиск сотрудника, 4: Удалить запись по ID\n");
                Console.Write("Введите команду: ");
                _codeOfOperation = Console.ReadLine();
                bool success = int.TryParse(_codeOfOperation, out _);
                if (success)
                {
                    switch (Convert.ToInt32(_codeOfOperation))
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
                            reposit.PrintTitles();
                            reposit.PrintAllWorkers();
                            break;
                        case 3:
                            SearchWorker();
                            break;
                        case 4:
                            Console.Write("Удаляем запись по с ID: ");
                            string id = Console.ReadLine();
                            reposit.DeleteWorkerByID(id);
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
            DateTime dateOfCreate = DateTime.Now;
            Console.WriteLine(dateOfCreate);
            Console.ReadKey();
            Worker worker = new Worker(newID, dateOfCreate, fullName, dateOfBirth, age);
            reposit.Add(worker);
        }

        static void SearchWorker()
        {
            Console.WriteLine("Поиск по полю: 1- ID, 2- ФИО, 3- По возрасту, 4- По диапазону дат");
            Console.Write("Код поля: ");
            _codeOfOperation = Console.ReadLine();
            bool success = int.TryParse(_codeOfOperation, out _);
            if (success)
            {
                switch (Convert.ToInt32(_codeOfOperation))
                {
                    case 0:
                        Console.WriteLine("В главное меню");
                        break;
                    case 1:
                        Console.WriteLine("Ищем по ID");
                        string id = Console.ReadLine();
                        reposit.PrintTitles();
                        reposit.SearchWorker(id);
                        break;
                    case 2:
                        Console.WriteLine("Ищем по ФИО ");
                        string name = Console.ReadLine();
                        reposit.PrintTitles();
                        reposit.SearchWorker(name);
                        break;
                    case 3:
                        Console.WriteLine("Ищем возрасту");
                        string age = Console.ReadLine();
                        reposit.PrintTitles();
                        reposit.SearchWorker(age);
                        break;
                    case 4:
                        Console.WriteLine("Ищем записи в диапазоне дат рождения:");
                        Console.Write("С даты: ");
                        string fromDate = Console.ReadLine();
                        Console.Write("По дату: ");
                        string toDate = Console.ReadLine();
                        if (DateTime.TryParse(fromDate, out _) && (DateTime.TryParse(toDate, out _)))
                        {
                            reposit.SearchWorkerByDateToDate(Convert.ToDateTime(fromDate), Convert.ToDateTime(toDate));
                        }
                        else
                        {
                            Console.WriteLine("Неверный формат даты. Проверьте водимые значения!");
                        }    
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
