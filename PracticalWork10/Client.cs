using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork10
{
    internal class Client
    {
        public int Id;
        public string Fio;
        public byte Age;

        public Client(int Id, string Fio, byte Age) 
            {
            this.Id = Id;
            this.Fio = Fio;
            this.Age = Age;
            }
    }
}
