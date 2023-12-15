namespace Task6.DAL.Interfaces
{
    internal interface IRepositoryWrite
    {
        void SaveCatalog(Catalog<string, Book> catalog);
    }
}
