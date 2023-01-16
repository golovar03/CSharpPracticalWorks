using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            PrintWords(SplitText(Console.ReadLine()));
            Console.ReadKey();
        }

        /// <summary>
        /// Метод получает строку с пробелами от пользователя, 
        /// делит ее по пробелам на отдельные слова, формируя массив строк string[] outputWords
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static string[] SplitText(string text)
        {
            string[] splitWords = text.Split(' ');
            return splitWords;
        }

        /// <summary>
        /// Метод получает от Метода SplitText массив строк string[] outputWords, перебирая его,
        /// выводит каждый его элемент "word" в отдельной строке на экран
        /// </summary>
        /// <param name="splitWords"></param>
        static void PrintWords(string[] splitWords)
        {
            foreach (var word in splitWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
