namespace Task6.AbstractFactory
{
    internal interface ILibrayAbstractFactory
    {
        List<string> CreatePressReleaseItems(string filePath);
        Catalog<string, Book> CreateCatalog(string filePath);
    }
}
