using Task6.AbstractFactory;
using Task6.Multithreading;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library libraryEbooks = LibraryBuilder.BuildLibrary("Ebook");
            PagesBuilder.BuildPages(libraryEbooks.Catalog);
        }
    }
}