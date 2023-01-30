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
        static void Main(string[] args)
        {
            string path = @"base.csv";
            Repository reposit = new Repository(path);
            //reposit.Load(path);
            int i = 0;
            while (i<5)
            {
                Console.Write("ФИО: ");
                string fullName = Console.ReadLine();
                Worker worker = new Worker(reposit.CountLineInFile(path), fullName);
                Console.WriteLine(worker.ID);
                Console.WriteLine(worker.FullName);
                reposit.Add(worker);
                i++;
            }
            
            //reposit.Save(path);
            Console.ReadKey();
        }

    }
}
