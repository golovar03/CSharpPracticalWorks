using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml.Linq;

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
            XDocument xDoc = XDocument.Load("XML_Base.xml");
            XElement? root = xDoc.Element("Persons");
            Stream writer = new FileStream(_path, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            root?.Add(new XElement("Persons", concretePerson.Select(p => new XElement("Person", new XAttribute("name", p.FullName),
                             new XElement("Address",
                             new XElement("Street", p.Street),
                             new XElement("Home", p.Home),
                             new XElement("Apartment", p.Apartment)),
                             new XElement("Phones",
                             new XElement("MobilePhone", p.MobilePhone),
                             new XElement("HomePhone", p.HomePhone))))));
            xDoc.Save(writer);
            writer.Close();
        }
    }
}
