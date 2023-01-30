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
            this.workers = new Worker[1];
            //this.Load();
        }

        public void Load(string path)
        {
            if (File.Exists(this.path))
            {
                using (StreamReader sr = new StreamReader(this.path))
                {
                    titles = sr.ReadLine().Split(',');
                    while (!sr.EndOfStream)
                    {
                        string[] args = sr.ReadLine().Split(',');
                        Add(new Worker(Convert.ToUInt32(args[0]), args[1]));
                    }
                }
            }
            else
            {
                using (StreamReader sr = new StreamReader(this.path))
                {
                    File.Create(this.path);
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
            this.Resize(index >= this.workers.Length);
            this.workers[index] = concreteWorker;
            this.index++;
        }

        public uint CountLineInFile(string Path)
        {
            uint linesCount = 1;
            if (File.Exists(this.path))
            {
                int nextLine = '\n';
                using (var streamReader = new StreamReader(
                    new BufferedStream(
                        File.OpenRead(Path), 10 * 1024 * 1024))) // буфер в 10 мегабайт
                {
                    while (!streamReader.EndOfStream)
                    {
                        if (streamReader.Read() == nextLine) linesCount++;
                    }
                }
            }
            return linesCount;
        }

        public void Save(string Path)
        {
            string temp;
            for (int i = 0; i < this.index; i++)
            {
                temp = String.Format("{0},{1}",
                                      this.workers[i].ID,
                                      this.workers[i].FullName);
                File.AppendAllText(Path, $"{temp}\n");
            }
            titles[0] = "ID";
            titles[1] = "Фамилия Имя Отчество"; 
            temp = String.Format("{0},{1}",
                                            this.titles[0],
                                            this.titles[1]);
            File.AppendAllText(Path, $"{temp}\n");
        }
    }
}
