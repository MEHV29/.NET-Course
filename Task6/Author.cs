using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task6
{
    public class Author : IXmlSerializable
    {
        string _firstName;
        string _lastName;
        string _dateBirth;

        public string FirstName
        {
            get => _firstName;
        }

        public string LastName
        {
            get => _lastName;
        }

        public string DateBirth
        {
            get => _dateBirth;
        }

        public Author()
        {

        }

        public Author(string firstName, string lastName, string dateBirth)
        {
            _firstName = firstName.Substring(0, Math.Min(firstName.Length, 200));
            _lastName = lastName.Substring(0, Math.Min(lastName.Length, 200));
            _dateBirth = dateBirth;
        }

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            reader.ReadStartElement("FirstName");
            _firstName = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("LastName");
            _lastName = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("DateBirth");
            _dateBirth = reader.ReadContentAsString();
            reader.ReadEndElement();
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("FirstName");
            writer.WriteValue(_firstName);
            writer.WriteEndElement();

            writer.WriteStartElement("LastName");
            writer.WriteValue(_lastName);
            writer.WriteEndElement();

            writer.WriteStartElement("DateBirth");
            writer.WriteValue(_dateBirth);
            writer.WriteEndElement();
        }

        public override bool Equals(object obj)
        {
            if (obj is not Author otherAuthor)
                return false;

            return _firstName == otherAuthor._firstName &&
                   _lastName == otherAuthor._lastName &&
                   _dateBirth == otherAuthor._dateBirth;
        }
    }
}
