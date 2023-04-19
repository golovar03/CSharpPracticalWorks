using Microsoft.SqlServer.Server;
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
        //string[] titles;
        public Repository(string Path)
        {
            this.path = Path;
            this.index = 0;
            //this.titles = new string[4];
            this.workers = new Worker[2];
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
            //string titles = String.Format("{0},{1},{2},{3}", "ID", "ФИО", "Дата рождения", "Возраст");
            this.Resize(index >= this.workers.Length);
            this.workers[index] = concreteWorker;
            string inputData = String.Format("{0},{1},{2},{3}", workers[index].ID, workers[index].FullName, workers[index].DateOfBirth, workers[index].Age);
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
                    //sw.Write(titles);
                    sw.Write(inputData);
                }
            }
            this.index++;
        }

        public String[,] ParseFile(string Path)
        {
            int dataLines = CountLines();
            string[,] data = new string[dataLines, 4];
            StreamReader sr = null;
            if (File.Exists(path))
            {
                using (sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        for (int j = 0; j < dataLines; j++)
                        {
                            string[] args = sr.ReadLine().Split(',');
                            for (int i = 0; i < args.Length; i++)
                            {
                                data[j, i] = args[i];
                            }
                        }
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
            return data;
        }

        public void SearchWorker(string param, string[,] data)
        {
            int lines = data.GetLength(0);
            int columns = data.GetLength(1);
            bool success = false;
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == 0)
                    {
                        Console.Write("{0,26}", data[0, j]);
                    }
                    if (data[i, j] == param)
                    {
                        Console.WriteLine();
                        for (j = 0; j < columns; j++)
                        {
                            Console.Write("{0,26}", data[i, j]);
                        }
                        success = true;
                    }
                }
            }
            Console.WriteLine();
            if (success == false)
            {
                Console.WriteLine("\nЗапись с указанными параметрами поиска не найдена. Попробуйте изменить параметры.");
            }
        }

        public void PrintAllWorkers(string[,] data)
        {
            int lines = data.GetLength(0);
            int columns = data.GetLength(1);
            for (int i = 0; i < lines; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (j == columns - 1)
                    {
                        Console.Write("{0,26}", data[i, j] + "\n");
                    }
                    else
                    {
                        Console.Write("{0,26}", data[i, j]);
                    }
                }
            }
        }

        public void DeleteWorkerByID(string workerID)
        {
            string searchID = workerID;
            string temp = @"temp.csv";

            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(temp))
                {
                    using (var streamReader = new StreamReader(
                                                new BufferedStream(
                                                    File.OpenRead(path), 10 * 1024 * 1024)))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string[] args = streamReader.ReadLine().Split(',');

                            if (args[0] != searchID)
                            {
                                string tempString = String.Format("{0},{1},{2},{3}", args[0], args[1], args[2], args[3]);
                                sw.Write(tempString);
                            }
                        }
                    }
                }
                File.Delete(path);
                File.Copy(temp, path);
                File.Delete(temp);
            }
            else
            {
                Console.WriteLine("Файла базы нет. Добавьте сотрудников в базу");
            }
            
        }
        public int CountLines()
        {
            var linesCount = 1;
            int nextLine = '\n';
            using (var streamReader = new StreamReader(
                new BufferedStream(
                    File.OpenRead(path), 10 * 1024 * 1024)))
            {
                while (!streamReader.EndOfStream)
                {
                    if (streamReader.Read() == nextLine) linesCount++;
                }
            }
            return linesCount;
        }
    }
}

