namespace Task6
{
    internal class EBook : Book
    {
        string _id;
        List<string> _formats;

        public string Id
        {
            get { return _id; }
        }

        public List<string> Formats
        {
            get { return _formats; }
        }
        public EBook(string title, List<Author> authors, string id, List<string> formats) : base(title, authors)
        {
            _id = id;
            _formats = formats;
        }
    }
}
