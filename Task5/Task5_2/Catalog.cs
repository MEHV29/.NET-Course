using System.Text.RegularExpressions;

namespace Task5_2
{
    internal class Catalog<isbn, book>
    {
        private Dictionary<isbn, book> _catalog;

        public book this[isbn key]
        {
            get
            {
                key = SimplifyString(key);

                if (_catalog.ContainsKey(key))
                {
                    return _catalog[key];
                }
                else
                {
                    return default(book);
                }
            }
            set
            {
                key = SimplifyString(key);

                _catalog[key] = value;
            }
        }

        public Catalog()
        {
            _catalog = new Dictionary<isbn, book>();
        }

        public void Add(isbn key, book value)
        {
            key = SimplifyString(key);

            _catalog.Add(key, value);
        }

        isbn SimplifyString(isbn isbn)
        {
            string keyCast = isbn.ToString();

            keyCast = Format(keyCast);

            return (isbn)(object)keyCast;
        }

        static string Format(string s)
        {
            string pattern = @"^.{13}(|\d{4})$|^\d{3}(-\d-\d{2}-\d{6}-\d|\d{13})$";

            if (!Regex.IsMatch(s, pattern))
            {
                throw new ArgumentException("Isbn is not valid");
            }
            else
            {
                return s.Replace("-", "");
            }
        }

        public IEnumerable<Book> OrderAlphabetically()
        {
            return _catalog.Values.Cast<Book>().OrderBy(book => book.Title);
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _catalog.Values.Cast<Book>().ToList().FindAll(book => book.Authors.Contains(author)).OrderBy(book => book.PublicationDate);
        }

        public IEnumerable<(string, int)> GetNumberBooksForAllAuthors()
        {
            return _catalog.Values
        .SelectMany(book => (book as Book).Authors.Where(author => !string.IsNullOrEmpty(author)),
            (book, author) => new { Author = author, Book = book })
        .GroupBy(pair => pair.Author)
        .OrderBy(group => group.Key)
        .Select(group => (group.Key, Count: group.Count()));
        }
    }
}
