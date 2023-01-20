using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testFile
{
    internal class Program
    {
        private const string PATH = @"E:\testDatabase\workers.txt";
        private const string NAMELINES = "ID:#Дата записи:#ФИО:#Возраст:#Рост:#Дата рождения:#Место рождения:";
        static void Main(string[] args)
        {
            string userChoice ="";
            
            while (userChoice !="3")
            {
                Console.WriteLine("Что делаем?\n| 1-Прочитать записи | 2-Добавить сотрудника |" +
                    " 3-Выход из программы |");
                userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ReadDataFromFile();
                        continue;
                    case "2":
                        AddDataToFile();
                        continue;
                    case "3": Console.WriteLine("Работа с базой окончена."); 
                        break;
                    default: continue;
                }
            }
            Console.ReadKey();
        }
        static void AddDataToFile()
        {
            Console.WriteLine("Введите данные нового сотрудника или нажмите ESC для завершения работы с базой");
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key != ConsoleKey.Escape)
            {
                string id = GetID();
                using (FileStream createOrRead = new FileStream(PATH, FileMode.Append))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(InputData(id));
                    createOrRead.Write(info, 0, info.Length);
                }
                Console.WriteLine("Данные внесены.\n");
            }
        }
        static void ReadDataFromFile()
        {
            if (File.Exists(PATH))
            {
                string[] lines = NAMELINES.Split('#');
                using (StreamReader readFile = File.OpenText(PATH))
                {
                    string correntLine;
                    while ((correntLine = readFile.ReadLine()) != null)
                    {
                        string[] parseString = correntLine.Split('#');
                        for (int i = 0; i < parseString.Length; i++)
                        {
                            Console.WriteLine(lines[i] + " " + parseString[i]);
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                Console.WriteLine($"Файл {PATH} не был найден.");
            }
        }
        static string InputData(string inputID)
        {
            string lineOfData;
            string id = inputID;
            Console.WriteLine($"ID: {id}");
            string dateOfLine = DateTime.Now.ToString();
            Console.WriteLine($"Дата записи: {dateOfLine}");
            Console.Write("ФИО: ");
            string fullnameOfWorker = Console.ReadLine();
            Console.Write("Возраст: ");
            byte ageOfWorker = byte.Parse(Console.ReadLine());
            Console.Write("Рост: ");
            double heightOfWorker = double.Parse(Console.ReadLine());
            Console.Write("Дата рождения: ");
            string birthday = (DateTime.Parse(Console.ReadLine()).Date).ToShortDateString();
            Console.Write("Место рождения: ");
            string placeOfBirth = Console.ReadLine();
            lineOfData = (id + "#" + dateOfLine + "#" + fullnameOfWorker + "#" + ageOfWorker + "#" +
                          +heightOfWorker + "#" + birthday + "#" + placeOfBirth + "\n");
            return lineOfData;
        }
        /// <summary>
        /// Метод пробегает по файлу, ищет символ перевода строки, после этого увеличивает значение
        /// linesCount на единицу. Когда все строки посчитаны, передает итоговое значение linesCount
        /// в переменную string ID метода AddDataToFile(), тем самым присваивая значение ID новой записи, 
        /// равное значению ID предыдущей записи +1 (простой счетчик) Если файл не найден, возвращает ID=1
        ///  (Первая запись новом созданном файле).
        /// </summary>
        /// <returns></returns>
        static string GetID()
        {
            var linesCount = 1;
            int nextLine = '\n';
            if (File.Exists(PATH))
                {
                using (var streamReader = new StreamReader(
                    new BufferedStream(
                        File.OpenRead(PATH), 1 * 1024 * 1024))) // буфер в 1 мегабайт
                {
                    while (!streamReader.EndOfStream)
                    {
                        if (streamReader.Read() == nextLine) linesCount++;
                    }
                }
                return linesCount.ToString();
            }
            else return linesCount.ToString();
        }
    }
}
