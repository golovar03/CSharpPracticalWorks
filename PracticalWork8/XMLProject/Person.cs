using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLProject
{
    public struct Person
    {
        public string FullName;
        public string Street;
        public string Home;
        public string Apartment;
        public string MobilePhone;
        public string HomePhone;

        public Person CreatePerson()
        {
            Console.Write("ФИО: ");
            FullName = Console.ReadLine();
            Console.Write("Улица: ");
            Street = Console.ReadLine();
            Console.Write("Номер дома: ");
            Home = Console.ReadLine();
            Console.Write("Номер квартиры: ");
            Apartment = Console.ReadLine();
            Console.Write("Номер сотового телефона: ");
            MobilePhone = Console.ReadLine();
            Console.Write("Номер домашнего телефона: ");
            HomePhone = Console.ReadLine();

            if (FullName !="" && Street !="" && Home != "")
            {
                Console.WriteLine("Данные внесены!");
            }
            else
            {
                Console.WriteLine("Вы ввели пустые значения!");
            }
            return this;
        }
    }
}