namespace Task6.AbstractFactory
{
    internal interface ILibrayAbstractFactory
    {
        List<string> CreatePressReleaseItems();
        Catalog<string, Book> CreateCatalog();
    }
}
