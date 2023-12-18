namespace Task6.AbstractFactory
{
    internal class EbookLibrayAbstractFactory : ILibrayAbstractFactory
    {
        public Catalog<string, Book> CreateCatalog()
        {
            throw new NotImplementedException();
        }

        public List<string> CreatePressReleaseItems()
        {
            throw new NotImplementedException();
        }
    }
}
