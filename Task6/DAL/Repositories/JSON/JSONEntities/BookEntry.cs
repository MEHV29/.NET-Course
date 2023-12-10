namespace Task6.DAL.Repositories.JSON.JSONEntities
{
    internal class BookEntry
    {
        public string ISBN { get; set; }
        public JSONBook Book { get; set; }

        public BookEntry(string iSBN, JSONBook book)
        {
            ISBN = iSBN;
            Book = book;
        }
    }
}
