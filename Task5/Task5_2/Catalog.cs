using System.Collections;
using System.Text.RegularExpressions;

namespace Task5_2
{
    internal class Catalog<isbn, book> : IEnumerable<book>
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

            if (keyCast.Contains("-"))
            {
                if (!CheckFormat(keyCast))
                {
                    throw new ArgumentException("Isbn is not valid");
                }

                keyCast = keyCast.Replace("-", "");
            }

            if (keyCast.Length < 13 || !ContainsOnlyNumbers(keyCast))
            {
                throw new ArgumentException("Isbn is not valid");
            }

            return (isbn)(object)keyCast;
        }

        static bool CheckFormat(string s)
        {
            string pattern = @"^\d{3}-\d-\d{2}-\d{6}-\d$";

            return Regex.IsMatch(s, pattern);
        }

        bool ContainsOnlyNumbers(string s)
        {
            return long.TryParse(s, out _);
        }

        public IEnumerable<Book> OrderAlphabetically()
        {
            List<Book> books = new List<Book>();

            foreach (var book in _catalog)
            {
                books.Add(book.Value as Book);
            }

            return books.OrderBy(book => book.Title);
        }

        public IEnumerable<Book> GetByAuthor(string author)
        {
            return _catalog.Values.Cast<Book>().ToList().FindAll(book => book.Authors.Contains(author)).OrderBy(book => book.PublicationDate);
        }

        public IEnumerable<(string, int)> GetNumberBooksForAllAuthors()
        {
            Dictionary<string, int> authorBookCount = new Dictionary<string, int>();

            foreach (var book in _catalog)
            {
                foreach (var author in (book.Value as Book).Authors)
                {
                    if (!string.IsNullOrEmpty(author))
                    {
                        if (authorBookCount.ContainsKey(author))
                        {
                            authorBookCount[author]++;
                        }
                        else
                        {
                            authorBookCount[author] = 1;
                        }
                    }
                }
            }

            return authorBookCount.OrderBy(author => author.Key).Select(pair => (pair.Key, pair.Value));
        }

        public IEnumerator<book> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
