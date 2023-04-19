﻿using System;
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
            Console.WriteLine("{0,22}{1,22}{2,22}{3,22}", worker._id, worker._fullName, worker._dateOfBirth, worker._age);  
        }

        public string ID { get { return _id; } }
        public string FullName { get { return this._fullName; } private set { _fullName = value; } }
        public DateTime DateOfBirth { get { return _dateOfBirth; } private set { _dateOfBirth = value; } }
        public int Age { get { return _age; } }

    }
}
