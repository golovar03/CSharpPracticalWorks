using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace PracticalWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задачи.\n1-Работа со списком.");
            Console.Write("Задача: ");
            string codeOfOperation = Console.ReadLine();
            if (int.TryParse(codeOfOperation, out int _))
            {
                while (Convert.ToInt32(codeOfOperation) != 0)
                {
                    switch (Convert.ToInt32(codeOfOperation))
                    {
                        case 1:
                            WorkWithList();
                            break;
                        default:
                            Console.WriteLine("Такой команды нет.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Неверный код или ошибка ввода");
            }
        }

        static void WorkWithList()
        {
            ListWork myList = new ListWork();
            Console.WriteLine("Заполняем список 100 случайными значениями от 0 до 100...");
            myList.PrintList(myList.CompleteTheList()); // заполняем список и выводим на экран
            Console.WriteLine("\nУдалим числа от 25 до 50 и выведем результат.");
            myList.PrintList(myList.DeleteValuesFrom25To50(25, 50)); // удаляем из списка числа из диапазона и выводим на экран
            Console.WriteLine();
        }
    }
}