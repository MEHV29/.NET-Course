namespace Task6.AbstractFactory
{
    internal class LibraryBuilder
    {
        public static Library BuildLibrary(string type)
        {
            ILibrayAbstractFactory libraryFactory;

            switch (type)
            {
                case "Ebook":
                    libraryFactory = new EbookLibrayAbstractFactory();
                    break;
                case "PaperBook":
                    libraryFactory = new PaperBookAbstractFactory();
                    break;
                default:
                    throw new ArgumentException();
            }

            Library library = new Library();
            library.Catalog = libraryFactory.CreateCatalog();
            library.PressReleaseItems = libraryFactory.CreatePressReleaseItems();

            return library;
        }
    }
}
