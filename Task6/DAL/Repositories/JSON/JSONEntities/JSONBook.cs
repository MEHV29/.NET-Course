namespace Task6.DAL.Repositories.JSON.JSONEntities
{
    public class JSONBook
    {
        public string Title { get; set; }
        public string PublicationDate { get; set; }
        public List<JSONAuthor> Authors { get; set; }
        public JSONBook() { }
        public JSONBook(string title, string publicationDate, List<JSONAuthor> authors)
        {
            Title = title;
            PublicationDate = publicationDate;
            Authors = authors;
        }

        public JSONBook(Book book)
        {
            Title = book.Title;
            PublicationDate = book.PublicationDate;
            Authors = book.Authors.ConvertAll(x => new JSONAuthor(x));
        }
    }
}
