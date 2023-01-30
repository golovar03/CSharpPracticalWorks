using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7_8
{
     struct Worker
    {
        private uint id;
        private string fullname;
        
        public Worker(uint ID, string FullName)
        {
            this.id = ID;
            this.fullname = FullName;
        }

        public uint ID { get { return this.id; } set { this.id = value; } }
        public string FullName { get { return this.fullname;} set { this.fullname = value; } }

        public string Print()
        {
            return $"{this.id,15} {this.fullname,15}";
        }
        
    }
}
