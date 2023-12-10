using System.Xml.Serialization;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories.XML.XMLEntities;

namespace Task6.DAL.Repositories.XML
{
    internal class XMLWriter : IRepositoryWrite
    {
        public void SaveCatalog(Catalog<string, Book> catalog)
        {
            XMLCatalog xMLCatalog = new XMLCatalog();
            xMLCatalog.CatalogEntrys = catalog.CatalogEntrys.ToDictionary(entry => entry.Key, entry => new XMLBook(entry.Value));
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(XMLCatalog));

            using (TextWriter writer = new StreamWriter("Catalog.xml"))
            {
                xmlSerializer.Serialize(writer, xMLCatalog);
            }
        }
    }
}
