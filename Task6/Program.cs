using Task6.AbstractFactory;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories.JSON;
using Task6.DAL.Repositories.XML;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRepositoryWrite repositoryWriteXML = new XMLWriter();
            IRespositoryRead respositoryReadXML = new XMLReader();

            IRepositoryWrite repositoryWriteJSON = new JSONWriter();
            IRespositoryRead respositoryReadJSON = new JSONReader();

            Library libraryPaperBooks = LibraryBuilder.BuildLibrary("PaperBook");

            repositoryWriteXML.SaveCatalog(libraryPaperBooks.Catalog);

            Catalog<string, Book> catalogXmlLibraryPaperBooks = respositoryReadXML.GetCatalog();
            Console.WriteLine($"Is equals XMLLibraryPaperBooks to Original Object? {libraryPaperBooks.Catalog.Equals(catalogXmlLibraryPaperBooks)}\n");

            repositoryWriteJSON.SaveCatalog(libraryPaperBooks.Catalog);

            Catalog<string, Book> catalogJSONsLibraryPaperBooks = respositoryReadJSON.GetCatalogByAuthors(libraryPaperBooks.Catalog);
            Console.WriteLine($"Are equals JSONsLibraryPaperBooks to Original Object? {libraryPaperBooks.Catalog.Equals(catalogJSONsLibraryPaperBooks)}\n");

            Console.WriteLine();

            Library libraryEbooks = LibraryBuilder.BuildLibrary("Ebook");
            
            repositoryWriteXML.SaveCatalog(libraryEbooks.Catalog);
            
            Catalog<string, Book> catalogXmlLibraryEbooks = respositoryReadXML.GetCatalog();
            Console.WriteLine($"Is equals XMLLibraryEbooks to Original Object? {libraryEbooks.Catalog.Equals(catalogXmlLibraryEbooks)}\n");
            
            repositoryWriteJSON.SaveCatalog(libraryEbooks.Catalog);
            
            Catalog<string, Book> catalogJSONsLibraryEbooks = respositoryReadJSON.GetCatalogByAuthors(libraryEbooks.Catalog);
            Console.WriteLine($"Are equals JSONsLibraryEbooks to Original Object? {libraryEbooks.Catalog.Equals(catalogJSONsLibraryEbooks)}");
        }
    }
}