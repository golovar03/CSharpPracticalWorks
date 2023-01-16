using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите предложение: ");
            Console.WriteLine(ReverseWords(Console.ReadLine()));
            Console.ReadKey();
        }

        static string[] SplitText(string text)
        {
            string[] splitWords = text.Split(' ');
            return splitWords;
        }

        static string ReverseWords(string inputPhrase)
        {
            string[] splitPhrase = SplitText(inputPhrase);
            for (int i = 0, j = splitPhrase.Length -1; i < j; i++, j--)
            {
                string temp = splitPhrase[i];
                splitPhrase[i] = splitPhrase[j];
                splitPhrase[j] = temp;
            }
            string resultReverse = string.Empty;
            foreach (var item in splitPhrase)
            {
                resultReverse = resultReverse + (item + " ");
            }
            return resultReverse;
        }
    }
}
