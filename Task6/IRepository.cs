namespace Task6
{
    internal interface IRepository
    {
        void Serialize(Catalog<string, Book> catalog);
        Catalog<string, Book> Deserialize();
    }
}
