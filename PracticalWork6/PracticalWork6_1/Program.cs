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
            while (true)
            {
                Console.WriteLine("Что делаем?\n| 1-Прочитать записи | 2-Добавить сотрудника |" +
                    " Enter-Выход их программы |");
                string userChoice = Console.ReadLine();
                if (File.Exists(PATH))
                {
                    switch (userChoice)
                    {
                        case "1":
                            ReadDataFromFile();
                            continue;
                        case "2":
                            AddDataToFile();
                            continue;
                        default: break;
                    }
                    Console.WriteLine("Работа с базой окончена.");
                    break;
                }
                else
                {
                    CreateEmptyFile();
                    continue;
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
                string ID = GetID();
                using (FileStream createOrRead = new FileStream(PATH, FileMode.Append))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(InputData(ID));
                    createOrRead.Write(info, 0, info.Length);
                }
                Console.WriteLine("Данные внесены.\n");
            }
        }
        static void ReadDataFromFile()
        {
            string[] lines = NAMELINES.Split('#');
            using (StreamReader readFile = File.OpenText(PATH))
            {
                string s;
                while ((s = readFile.ReadLine()) != null)
                {
                    string[] parse = s.Split('#');
                    for (int i = 0; i < parse.Length; i++)
                    {
                        for (int j = 0; j < lines.Length; j++)
                        {
                            if (i == j)
                            {
                                Console.WriteLine(lines[j] + " " + parse[i]);
                            }
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
        static string InputData(string inputID)
        {
            string lineOfData;
            string ID = inputID;
            Console.WriteLine($"ID: {ID}");
            string dateOfLine = DateTime.Now.ToString();
            Console.WriteLine($"Дата записи: {dateOfLine}");
            Console.Write("ФИО: ");
            string FIO = Console.ReadLine();
            Console.Write("Возраст: ");
            byte age = byte.Parse(Console.ReadLine());
            Console.Write("Рост: ");
            double height = double.Parse(Console.ReadLine());
            Console.Write("Дата рождения: ");
            string birthday = (DateTime.Parse(Console.ReadLine()).Date).ToShortDateString();
            Console.Write("Место рождения: ");
            string placeOfBirth = Console.ReadLine();
            lineOfData = (ID + "#" + dateOfLine + "#" + FIO + "#" + age + "#" +
                          +height + "#" + birthday + "#" + placeOfBirth + "\n");
            return lineOfData;
        }
        /// <summary>
        /// Метод пробегает по файлу, ищет символ перевода строки, после этого увеличивает значение
        /// linesCount на единицу. Когда все строки посчитаны, передает итоговое значение linesCount
        /// в переменную string ID метода AddDataToFile(), тем самым присваивая значение ID новой записи, 
        /// равное значению ID предыдущей записи +1 (простой счетчик).
        /// </summary>
        /// <returns></returns>
        static string GetID()
        {
            var linesCount = 1;
            int nextLine = '\n';
            using (var streamReader = new StreamReader(
                new BufferedStream(
                    File.OpenRead(PATH), 10 * 1024 * 1024))) // буфер в 10 мегабайт
            {
                while (!streamReader.EndOfStream)
                {
                    if (streamReader.Read() == nextLine) linesCount++;
                }
            }
            return linesCount.ToString();
        }
        static void CreateEmptyFile()
        {
            using (FileStream createFile = new FileStream(PATH, FileMode.Create))
            {
            }
            Console.WriteLine($"Файл не был найден. Был создан новый пустой файл: {PATH}");
        }
    }
}
