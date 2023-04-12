using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7_8
{
     struct Worker
    {
        private uint _id;
        private string _fullMame;
        private DateTime _dateOfBirth;
        private int _age;
        
        public Worker(uint ID, string FullName, DateTime DateOfBirth, int Age) : this()
        {
            _id = ID;
            _fullMame = FullName;
            _dateOfBirth = DateOfBirth;
            _age = Age;
        }

        public uint ID { get { return _id; } private set {  _id = value; } }
        public string FullName { get { return this._fullMame; } set { _fullMame = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }
        public int Age { get { return _age; } }

    }
}
