using System.Xml.Serialization;
using System.Xml;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories.XML.XMLEntities;

namespace Task6.DAL.Repositories.XML
{
    internal class XMLReader : IRespositoryRead
    {
        public Catalog<string, Book> GetCatalog()
        {
            using (var reader = XmlReader.Create("Catalog.xml"))
            {
                var serializer = new XmlSerializer(typeof(XMLCatalog));
                var xmlCatalog = (XMLCatalog)serializer.Deserialize(reader);
                return new Catalog<string, Book>(xmlCatalog);
            }
        }

        public Catalog<string, Book> GetCatalogByAuthors(Catalog<string, Book> catalog)
        {
            throw new NotImplementedException();
        }
    }
}
