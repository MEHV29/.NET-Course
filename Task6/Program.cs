using Task6.AbstractFactory;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library libraryEbooks = LibraryBuilder.BuildLibrary("Ebook");
        }
    }
}