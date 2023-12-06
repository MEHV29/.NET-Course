using System.Xml;
using System.Xml.Serialization;

namespace Task6
{
    internal class XMLRepository : IRepository
    {
        public Catalog<string, Book> Deserialize()
        {
            using (var reader = XmlReader.Create("Catalog.xml"))
            {
                var serializer = new XmlSerializer(typeof(Catalog<string, Book>));
                return (Catalog<string, Book>)serializer.Deserialize(reader);
            }
        }

        public void Serialize(Catalog<string, Book> catalog)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Catalog<string, Book>));

            using (TextWriter writer = new StreamWriter("Catalog.xml"))
            {
                xmlSerializer.Serialize(writer, catalog);
            }
        }
    }
}
