using System.Diagnostics.Contracts;
using System.Reflection.Metadata.Ecma335;

namespace PracticalWork8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Приложение запущено. Нажмите Enter.");
            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Введите номер задачи.\n1- Работа со списком\t2- Телефонный справочник\tEsc- Выход из приложения");
                Console.Write("Ваш выбор: ");
                string codeOfOperation = Console.ReadLine();
                if (!String.IsNullOrEmpty(codeOfOperation) & Int32.TryParse(codeOfOperation, out _))
                {
                    switch (Convert.ToInt32(codeOfOperation))
                    {
                        case 0:
                            Console.WriteLine("Работа с приложением завершена.");
                            break;
                        case 1:
                            WorkWithList();
                            break;
                        case 2:
                            WorkWithPhonebook();
                            break;
                        default:
                            Console.WriteLine("Такой команды нет.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный код операции или пустое значение. Повторите ввод!");
                }
            }
        }

        static void WorkWithList()
        {
            ListWork myList = new ListWork();
            Console.WriteLine("Заполняем список 100 случайными значениями от 0 до 100...");
            myList.PrintList(myList.CompleteTheList()); // заполняем список и выводим на экран
            Console.WriteLine("\nУдалим числа от 25 до 50 и выведем результат.");
            myList.PrintList(myList.DeleteInRange(25, 50)); // удаляем из списка числа из диапазона и выводим на экран измененный список
            Console.WriteLine();
        }

        static void WorkWithPhonebook()
        {

            PhoneBook phoneBook = new PhoneBook();

            while (Console.ReadKey(true).Key != ConsoleKey.Escape)
            {
                Console.WriteLine("Работаем с телефонным справочником\n1-Добавить абонента\t2-Удалить абонента по номеру\t3-Вывести все записи" +
                    "\t4-Поиск по номеру\tEsc- В главное меню");
                Console.Write("Ваш выбор: ");
                string codeOfOperation = Console.ReadLine();
                if (!String.IsNullOrEmpty(codeOfOperation) & Int32.TryParse(codeOfOperation, out _))
                {
                    switch (Convert.ToInt32(codeOfOperation))
                    {
                        case 0:
                            Console.WriteLine("Работа со справочником завершена.");
                            break;
                        case 1:
                            AddSubcriber(phoneBook);
                            break;
                        case 2:
                            Console.Write("Введите номер телефона, чтобы удалить его данные: ");
                            phoneBook.DeleteSubscriber(Console.ReadLine());
                            break;
                        case 3:
                            phoneBook.PrintAllSubscribes();
                            break;
                        case 4:
                            phoneBook.FindByNumber(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Такой команды нет.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный код операции или пустое значение. Повторите ввод!");
                }
            }
        }

        static PhoneBook AddSubcriber(PhoneBook phoneBook)
        {
            bool data = true;
            while (data)
            {
                Console.Write("Номер телефона: ");
                string phoneNumber = Console.ReadLine();
                if (!String.IsNullOrEmpty(phoneNumber))
                {
                    Console.Write("ФИО: ");
                    string fullName = Console.ReadLine();
                    phoneBook.AddSubcriber(phoneNumber, fullName);
                    continue;
                }
                else
                {
                    data = false;
                }
            }
            return phoneBook;
        }
    }
}