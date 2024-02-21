using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ADONET_hw_5
{
    internal class User
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public User(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public XElement ToXml() =>
           new XElement("user",
               new XAttribute("id", Id),
               new XElement("firstName", FirstName),
               new XElement("lastName", LastName));

        public static User FromXml(XElement node) =>
    new User(
        (int)node.Attribute("id"),
        (string)node.Element("firstName"),
        (string)node.Element("lastName"));

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
