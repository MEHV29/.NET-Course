namespace Task5_2
{
    internal class Book
    {
        string _title;
        string _publicationDate;
        List<string> _authors;

        public string Title
        {
            get { return _title; }
        }
        public string PublicationDate
        {
            get { return _publicationDate; }
        }
        public List<string> Authors
        {
            get { return _authors; }
        }

        public Book(string title, string publicationDate, List<string> authors)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentNullException("title is null");
            }

            _title = title;
            _publicationDate = publicationDate;
            _authors = authors;
        }
    }
}
