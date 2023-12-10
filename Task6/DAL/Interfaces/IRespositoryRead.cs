namespace Task6.DAL.Interfaces
{
    internal interface IRespositoryRead
    {
        Catalog<string, Book> GetCatalog();
    }
}
