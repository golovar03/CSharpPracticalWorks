using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PracticalWork7_8
{
    internal class Program
    {
        static readonly string path = @"base.csv";
        static Repository reposit = new Repository(path);
        static void Main(string[] args)
        {
            int codeOfOperation = -1;
            Console.WriteLine("0 - Выход, 1: Добавить сотрудника, 2: Вывести все записи, 3: Поиск по ID, 4: Удалить запись по ID");
            while (codeOfOperation != 0)
            {
                Console.Write("Введите команду: ");
                codeOfOperation = int.Parse(Console.ReadLine());
                switch (codeOfOperation)
                {
                    case 0: Console.WriteLine("Работа с приложением завершена");
                        break;
                    case 1: CreateWorkwer();
                        break;
                    case 2: reposit.PrintAllWorkers(path);
                        break;
                }
                continue;
            }
            Console.ReadKey();         
        }
        static void CreateWorkwer()
        {
            Console.Write("ФИО сотрудника: ");
            string fullName = Console.ReadLine();
            Console.Write("Дата рождения: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());
            byte age = Convert.ToByte(Convert.ToInt64((DateTime.Now.Date - dateOfBirth.Date).TotalDays) / 365);
            Console.Write("Возраст: ");
            Console.WriteLine(age);
            Worker worker = new Worker(reposit.CountLineInFile(path), fullName, dateOfBirth, age);
            reposit.Add(worker);
        }
    }
}
