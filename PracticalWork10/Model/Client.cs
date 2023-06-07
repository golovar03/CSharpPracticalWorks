using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork10.Model
{
    internal class Client
    {
        private int _id;
        private string _secondName;
        private string _firstName;
        private string _lastName;
        private string _passportNumber;
        private string _phoneNumber;
        private DateTime _editDataTime;
        private string _comment;

        public int ID 
        { get 
            { 
                return _id; 
            } 
        }

        public string SecondName
        {
            get { return _secondName; }
            set { _secondName = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string PassportNumber
        { get { return _passportNumber; }
            set
            {
                _passportNumber = value;
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                if(value !=null)
                _phoneNumber = value;
                else
                    _phoneNumber = "не указан!";
            }
        }

        public DateTime EditDataTime
        {
            get { return _editDataTime; }
            set
            {
                _editDataTime = value.Date;
            }
        }
        public string Comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
            }
        }
    }
}
