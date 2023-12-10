using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task6.DAL.Repositories.XML.XMLEntities
{
    [XmlRoot("Catalog")]
    public class XMLCatalog : IXmlSerializable
    {
        public Dictionary<string, XMLBook> CatalogEntrys { get; set; }
        public XMLCatalog() { CatalogEntrys = new Dictionary<string, XMLBook>(); }

        public XmlSchema? GetSchema() { return null; }

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "CatalogEntry")
                {
                    string isbn = default(string);
                    XMLBook book = default(XMLBook);

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "CatalogEntry")
                            break;

                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "ISBN":
                                    reader.Read();
                                    isbn = reader.Value.ToString();
                                    break;

                                case "Book":
                                    var bookSerializer = new XmlSerializer(typeof(XMLBook));
                                    book = (XMLBook)bookSerializer.Deserialize(reader);
                                    break;
                            }
                        }
                    }
                    CatalogEntrys.Add(isbn, book);
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var item in CatalogEntrys)
            {
                writer.WriteStartElement("CatalogEntry");

                writer.WriteStartElement("ISBN");
                writer.WriteValue(item.Key.ToString());
                writer.WriteEndElement();

                var bookSerializer = new XmlSerializer(typeof(XMLBook));
                bookSerializer.Serialize(writer, item.Value);

                writer.WriteEndElement();
            }
        }
    }
}
