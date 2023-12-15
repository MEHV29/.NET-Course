using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task6.DAL.Repositories.XML.XMLEntities
{
    [XmlRoot("Author")]
    public class XMLAuthor: IXmlSerializable
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateBirth { get; set; }
        public XMLAuthor() { }

        public XMLAuthor(Author author)
        {
            this.FirstName = author.FirstName;
            this.LastName = author.LastName;
            this.DateBirth = author.DateBirth;
        }

        public XmlSchema? GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            reader.ReadStartElement("FirstName");
            FirstName = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("LastName");
            LastName = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("DateBirth");
            DateBirth = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("FirstName");
            writer.WriteValue(FirstName);
            writer.WriteEndElement();

            writer.WriteStartElement("LastName");
            writer.WriteValue(LastName);
            writer.WriteEndElement();

            writer.WriteStartElement("DateBirth");
            writer.WriteValue(DateBirth);
            writer.WriteEndElement();
        }
    }
}
