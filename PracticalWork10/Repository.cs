using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork10
{
    internal class Repository
    {
        private readonly string _path;
        private Client[] _clients;
        private int _index;

        public Repository(string Path)
        {
            _path = Path;
            _index = 0;
            _clients = new Client[2];
        }
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref this._clients, this._clients.Length * 2);
            }
        }

        public void Add(Client concreteClient)
        {
            this.Resize(_index >= this._clients.Length);
            this._clients[_index] = concreteClient;
            string InputData = String.Format("{0}, {1}, {2}", _clients[_index].Id, _clients[_index].Fio, _clients[_index].Age + "\n");

            if (File.Exists(_path))
            {
                using (StreamWriter sw = File.AppendText(_path))
                {
                    sw.Write(InputData);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(_path, FileMode.Create), Encoding.UTF8))
                {
                    sw.Write(InputData);
                }
            }
            this._index++;
        }
    }
}
