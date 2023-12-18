namespace Task6
{
    internal class PaperBook : Book
    {
        List<string> _isbns;
        string _publisher;

        public List<string> Isbns
        {
            get { return _isbns; }
        }

        public string Publisher
        {
            get { return _publisher; }
        }

        public PaperBook(string title, string publicationDate, List<Author> authors, List<string> isbns, string publisher) : base(title, publicationDate, authors)
        {
            _isbns = isbns;
            _publisher = publisher;
        }
    }
}
