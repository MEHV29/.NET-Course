namespace Task6
{
    internal class PaperBook : Book
    {
        List<string> _isbns;
        List<string> _publishers;

        public List<string> Isbns
        {
            get { return _isbns; }
        }

        public List<string> Publishers
        {
            get { return _publishers; }
        }

        public PaperBook(string title, string publicationDate, List<Author> authors, List<string> isbns, List<string> publishers, bool isbnIsNull) : base(title, publicationDate, authors, isbnIsNull)
        {
            _isbns = isbns;
            _publishers = publishers;
        }
    }
}
