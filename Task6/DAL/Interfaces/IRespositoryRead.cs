namespace Task6.DAL.Interfaces
{
    internal interface IRespositoryRead
    {
        Catalog<string, Book> GetCatalog();
        Catalog<string, Book> GetCatalogByAuthors(Catalog<string, Book> catalog);
    }
}
