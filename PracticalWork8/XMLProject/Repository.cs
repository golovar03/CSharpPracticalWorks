using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.ComponentModel.Design;

namespace XMLProject
{
    internal readonly struct Repository
    {
        private static readonly string _path = @"XML_Base.xml";

        public Repository()
        {

        }

        public static void AddPerson(List<Person> concretePerson)
        {
            if (!File.Exists(_path))
            {
                XDocument xDoc = new(new XElement("Persons", concretePerson.Select(p => new XElement("Person", new XAttribute("name", p.FullName),
                           new XElement("Address",
                           new XElement("Street", p.Street),
                           new XElement("Home", p.Home),
                           new XElement("Apartment", p.Apartment)),
                           new XElement("Phones",
                           new XElement("MobilePhone", p.MobilePhone),
                           new XElement("HomePhone", p.HomePhone))))));
                xDoc.Save(_path);
            }
            else
            {
                XDocument xDoc = XDocument.Load(_path);
                XElement? root = xDoc.Element("Persons");
                if (root != null)
                    {
                        root?.Add(concretePerson.Select(p => new XElement("Person", new XAttribute("name", p.FullName),
                                 new XElement("Address",
                                 new XElement("Street", p.Street),
                                 new XElement("Home", p.Home),
                                 new XElement("Apartment", p.Apartment)),
                                 new XElement("Phones",
                                 new XElement("MobilePhone", p.MobilePhone),
                                 new XElement("HomePhone", p.HomePhone)))));
                    xDoc.Save(_path);
                }
                else
                {
                    Console.WriteLine("Обнаружено нарушение структуры файла базы. Возможно файл поврежден.");
                }
            }
        }
    }
}