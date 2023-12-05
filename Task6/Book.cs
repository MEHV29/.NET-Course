using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task6
{
    public class Book : IXmlSerializable
    {
        string _title;
        string _publicationDate;
        List<Author> _authors;

        public string Title
        {
            get { return _title; }
        }
        public string PublicationDate
        {
            get { return _publicationDate; }
        }
        public List<Author> Authors
        {
            get { return _authors; }
        }

        public Book()
        {

        }

        public Book(string title, string publicationDate, List<Author> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title is null");
            }

            _title = title;
            _publicationDate = publicationDate;
            _authors = authors;
        }

        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();
            reader.ReadStartElement("Title");
            _title = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("PublicationDate");
            _publicationDate = reader.ReadContentAsString();
            reader.ReadEndElement();

            reader.ReadStartElement("Authors");
            _authors = new List<Author>();
            while (reader.IsStartElement("Author"))
            {
                var authorSerializer = new XmlSerializer(typeof(Author));
                //reader.ReadStartElement("Author");
                var author = (Author)authorSerializer.Deserialize(reader);
                _authors.Add(author);
                //reader.ReadEndElement();
            }
            reader.ReadEndElement();
            reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Title");
            writer.WriteValue(_title);
            writer.WriteEndElement();

            writer.WriteStartElement("PublicationDate");
            writer.WriteValue(_publicationDate);
            writer.WriteEndElement();

            writer.WriteStartElement("Authors");
            foreach (var item in _authors)
            {
                var authorSerializer = new XmlSerializer(typeof(Author));
                authorSerializer.Serialize(writer, item);
            }
            writer.WriteEndElement();
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Book otherBook)
                return false;

            return _title == otherBook._title &&
               _publicationDate == otherBook._publicationDate &&
               AuthorsEqual(_authors, otherBook._authors);
        }

        private bool AuthorsEqual(List<Author> authors1, List<Author> authors2)
        {
            if (authors1.Count != authors2.Count)
                return false;

            for (int i = 0; i < authors1.Count; i++)
            {
                if (!authors1[i].Equals(authors2[i]))
                    return false;
            }

            return true;
        }
    }
}
