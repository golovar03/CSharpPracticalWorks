using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork7_8
{
     struct Worker
    {
        private string _id;
        private string _fullName;
        private DateTime _dateOfBirth;
        private int _age;
        
        public Worker(string Id, string FullName, DateTime DateOfBirth, int Age) : this()
        {
            _id = Id;
            _fullName = FullName;
            _dateOfBirth = DateOfBirth;
            _age = Age;
        }

        public void Print(Worker worker)
        {
            Console.WriteLine($"{worker._id}\t{worker._fullName}\t{worker._dateOfBirth}\t{worker._age}");  
        }

        public string ID { get { return _id; } set {  _id = value; } }
        public string FullName { get { return this._fullName; } set { _fullName = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; } }
        public int Age { get { return _age; } set { _age = value; } }

    }
}
