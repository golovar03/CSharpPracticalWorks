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
        private Worker[] _workers;
        private readonly string _path;
        private int _index;
        
        public Repository(string Path)
        {
            this._path = Path;
            this._index = 0;
            this._workers = new Worker[2];
        }

        public void PrintTitles()
        {
            string titles = String.Format("{0,26}{1,28}{2,26}{3,22}{4,15}", "ID", "Дата создания", "ФИО", "Дата рождения", "Возраст");
            Console.WriteLine(titles);
        }
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this._workers, this._workers.Length * 2);
            }
        }

        public void Add(Worker concreteWorker)
        {
            this.Resize(_index >= this._workers.Length);
            this._workers[_index] = concreteWorker;
            string inputData = String.Format("{0},{1},{2},{3},{4}", _workers[_index].ID, _workers[_index].CreatedDate, _workers[_index].FullName,
                                                                    _workers[_index].DateOfBirth.ToString("d"), _workers[_index].Age + "\n");
            if (File.Exists(_path))
            {
                using (StreamWriter sw = File.AppendText(_path))
                {
                    sw.Write(inputData);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(_path, FileMode.Create), Encoding.UTF8))
                {
                    sw.Write(inputData);
                }
            }
            this._index++;
        }

        public void SearchWorker(string param)
        {
            bool success = false;
            if (File.Exists(_path))
            {
                using (var streamReader = new StreamReader(new BufferedStream(File.OpenRead(_path), 10 * 1024 * 1024)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] args = streamReader.ReadLine().Split(',');
                        {
                            for (int i = 0; i < args.Length; i++)
                            {
                                if (args[i].Equals(param))
                                {
                                    success = true;
                                    string printString = String.Format("{0,23}{1,23}{2,23}{3,20}{4,12}", args[0], args[1], args[2], args[3], args[4]);
                                    Console.WriteLine(printString);
                                }
                            }
                        }
                    }
                }
                if (success == false)
                {
                    Console.WriteLine("\nЗапись с указанными параметрами поиска не найдена. Попробуйте изменить параметры.");
                }
            }
            else
            {
                Console.WriteLine("Файл базы данных не найден или пустой. Добавьте сотрудников в базу!");
            }
        }

        public void SearchWorkerByDateToDate(DateTime fromDate, DateTime toDate)
        {
            bool success = false;
            if(File.Exists(_path)) 
            {
                using (var streamReader = new StreamReader(new BufferedStream(File.OpenRead(_path), 10 * 1024 * 1024)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] args = streamReader.ReadLine().Split(',');
                        {
                            for (int i = 0; i < args.Length; i++)
                            {
                                if (Convert.ToDateTime(args[3]) >= fromDate && Convert.ToDateTime(args[3]) <= toDate)
                                {
                                    success = true;
                                    string printString = String.Format("{0,23}{1,23}{2,23}{3,20}{4,12}", args[0], args[1], args[2], args[3], args[4]);
                                    Console.WriteLine(printString);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл базы данных не найден или пустой. Добавьте сотрудников в базу!");
            }
            
            if (success == false)
            {
                Console.WriteLine("\nЗапись с указанными параметрами поиска не найдена. Попробуйте изменить параметры.");
            }
        }

        public void PrintAllWorkers()
        {
            if (File.Exists(_path))
            {
                using (var streamReader = new StreamReader(new BufferedStream(File.OpenRead(_path), 10 * 1024 * 1024)))
                {
                    while (!streamReader.EndOfStream)
                    {
                        string[] args = streamReader.ReadLine().Split(',');
                        {
                            string printString = String.Format("{0,23}{1,23}{2,23}{3,20}{4,12}", args[0], args[1], args[2], args[3], args[4]);
                            Console.WriteLine(printString);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл базы данных не найден или пустой. Добавьте сотрудников в базу!");
            }
        }
        public void DeleteWorkerByID(string workerID)
        {
            string searchID = workerID;
            string temp = @"temp.csv";

            if (File.Exists(_path))
            {
                using (StreamWriter sw = File.AppendText(temp))
                {
                    bool fileFinded = false;
                    using (var streamReader = new StreamReader(new BufferedStream(File.OpenRead(_path), 10 * 1024 * 1024)))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            string[] args = streamReader.ReadLine().Split(',');
                            if (!args[0].Equals(searchID))
                            {
                                fileFinded = true;
                                string tempString = String.Format("{0},{1},{2},{3},{4}", args[0], args[1], args[2], args[3], args[4] + "\n");
                                sw.Write(tempString);
                            }
                        }
                    }
                    if (fileFinded == false)
                    {
                        Console.WriteLine("Не удалось найти сотрудника с данным ID");
                    }
                }
                File.Delete(_path);
                File.Copy(temp, _path);
                File.Delete(temp);
            }
            else
            {
                Console.WriteLine("Файл базы данных не найден или пустой. Добавьте сотрудников в базу!");
            }
        }
    }
}

