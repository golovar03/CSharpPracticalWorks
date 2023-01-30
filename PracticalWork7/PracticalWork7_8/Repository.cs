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
            //this.Load();
        }

        public void Load(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
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
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine("ID,FIO");
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
            string titles = String.Format("{0},{1}", "ID", "FIO");
            this.Resize(index >= this.workers.Length);
            this.workers[index] = concreteWorker;
            string inputData = String.Format("{0},{1}", "\n" + this.workers[index].ID, this.workers[index].FullName);
            if (File.Exists(path))
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(inputData);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write(titles);
                    sw.Write(inputData);
                }
            }
            this.index++;
        }

        public uint CountLineInFile(string Path)
        {
            uint linesCount = 1;
            if (File.Exists(path))
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
        }
    }
}
