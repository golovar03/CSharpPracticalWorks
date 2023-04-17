using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7_8
{
    struct Repository
    {
        private Worker[] workers;
        private string path;
        int index;
        string[] titles;
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            this.titles = new string[2];
            this.workers = new Worker[2];
        }
        public void PrintAllWorkers(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    titles = sr.ReadLine().Split(',');
                    for (int i = 0; i < titles.Length; i++)
                    {
                        Console.Write("{0,26}", titles[i]);
                    }
                    Console.WriteLine();
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');
                        for (int i = 0; i < args.Length; i++)
                        {
                            Console.Write("{0,22}",args[i]);
                        }
                        Console.WriteLine();
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("ID,ФИО,Дата рождения,Возраст");
                }
            }
        }

        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }

        public void Add(Worker concreteWorker)
        {
            string titles = String.Format("{0},{1},{2},{3}", "ID", "ФИО", "Дата рождения", "Возраст");
            this.Resize(index >= this.workers.Length);
            this.workers[index] = concreteWorker;
            string inputData = String.Format("{0},{1},{2},{3}", "\n" + this.workers[index].ID, this.workers[index].FullName, this.workers[index].DateOfBirth, this.workers[index].Age);
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(inputData);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.UTF8))//File.AppendText(path))
                {
                    sw.Write(titles);
                    sw.Write(inputData);
                }
            }
            this.index++;
        }

        public void SearchWorker(string Path, string param)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    titles = sr.ReadLine().Split(',');
                    for (int i = 0; i < titles.Length; i++)
                    {
                        Console.Write($"{titles[i]}\t");
                    }
                    Console.WriteLine();
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');
                        for (int i = 0; i < args.Length; i++)
                        {
                            for (int j = 0; j < this.workers.Length; j++)
                            {
                                this.workers[j] = new Worker(args[0], args[1], DateTime.Parse(args[2]), Convert.ToInt32(args[3]));
                                //this.workers[j].ID = args[0];
                                //this.workers[j].FullName = args[1];
                                //this.workers[j].DateOfBirth = DateTime.Parse(args[2]);
                                //this.workers[j].Age = Convert.ToInt32(args[3]);
                            }
                        }
                        foreach (Worker worker in this.workers)
                        {
                            if (worker.FullName == param)
                            {
                                worker.Print(worker);
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("ID,ФИО,Дата рождения,Возраст,");
                }
            }
        }

    }
}

