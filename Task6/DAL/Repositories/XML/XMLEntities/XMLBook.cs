using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task6.DAL.Repositories.XML.XMLEntities
{
    [XmlRoot("Book")]
    public class XMLBook : IXmlSerializable
    {
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public List<XMLAuthor> Authors { get; set; }
        public XMLBook() { }

        public XMLBook(Book book)
        {
            this.Title = book.Title;
            this.PublicationDate = book.PublicationDate;
            this.Authors = book.Authors.ConvertAll(x => new XMLAuthor(x));
        }

        public XmlSchema? GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            reader.ReadStartElement("Title");
            Title = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("PublicationDate");
            PublicationDate = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("Authors");
            Authors = new List<XMLAuthor>();
            while (reader.IsStartElement("Author"))
            {
                var authorSerializer = new XmlSerializer(typeof(XMLAuthor));
                var author = (XMLAuthor)authorSerializer.Deserialize(reader);
                Authors.Add(author);
            }
            reader.ReadEndElement();

            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Title");
            writer.WriteValue(Title);
            writer.WriteEndElement();

            writer.WriteStartElement("PublicationDate");
            writer.WriteValue(PublicationDate);
            writer.WriteEndElement();

            writer.WriteStartElement("Authors");
            foreach (var author in Authors)
            {
                var serializer = new XmlSerializer(typeof(XMLAuthor));
                serializer.Serialize(writer, author);
            }
            writer.WriteEndElement();
        }
    }
}
