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
        private DateTime _createdDate;
        private string _fullName;
        private DateTime _dateOfBirth;
        private int _age;
        
        public Worker(string Id, DateTime CreatedDate, string FullName, DateTime DateOfBirth, int Age) : this()
        {
            _id = Id;
            _createdDate = CreatedDate;
            _fullName = FullName;
            _dateOfBirth = DateOfBirth;
            _age = Age;
        }

        public void Print(Worker worker)
        {
            Console.WriteLine("{0,22}{0,20}{1,20}{2,20}{3,20}", worker._id, worker._createdDate, worker._fullName, worker._dateOfBirth, worker._age);  
        }

        public string ID { get { return _id; } }
        public DateTime CreatedDate { get { return _createdDate; }}
        public string FullName { get { return this._fullName; } private set { _fullName = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } private set { _dateOfBirth = value; } }
        public int Age { get { return _age; } }
    }
}
