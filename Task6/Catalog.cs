using System.Text.RegularExpressions;
using Task6.DAL.Repositories.XML.XMLEntities;

namespace Task6
{
    internal class Catalog<isbn, book>
    {
        private Dictionary<isbn, book> _catalog;

        public Dictionary<isbn, book> CatalogEntrys
        {
            get => _catalog;
        }

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

        public Catalog(XMLCatalog xmlCatalog)
        {
            _catalog = new Dictionary<isbn, book>();
            _catalog = xmlCatalog.CatalogEntrys.ToDictionary(entry => (isbn)(object)entry.Key, entry => (book)(object)new Book(entry.Value));
        }

        public void Add(isbn key, book value)
        {
            key = SimplifyString(key);

            try
            {
                _catalog.Add(key, value);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    _catalog[key] = value;
                }
            }
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

        public IEnumerable<Book> GetByAuthor(Author author)
        {
            return _catalog.Values.Cast<Book>().ToList().FindAll(book => book.Authors.Contains(author)).OrderBy(book => book.PublicationDate);
        }

        public IEnumerable<(string, int)> GetNumberBooksForAllAuthors()
        {
            return _catalog.Values.SelectMany(book => (book as Book).Authors, (book, author) => $"{author.FirstName} {author.LastName}")
        .Where(authorFullName => authorFullName != null)
        .GroupBy(authorFullName => authorFullName)
        .OrderBy(group => group.Key)
        .Select(group => (group.Key, Count: group.Count()));
        }

        public IEnumerable<(Author, List<(string, Book)>)> GetBooksForAllAuthors()
        {
            return _catalog
        .SelectMany(pair => (pair.Value as Book).Authors, (pair, author) => new { Author = author, BookInfo = (pair.Key.ToString(), pair.Value as Book) })
        .Where(info => info.Author != null)
        .GroupBy(info => info.Author)
        .OrderBy(group => group.Key)
        .Select(group => (group.Key, Books: group.Select(info => info.BookInfo).ToList()));
        }

        public override bool Equals(object? obj)
        {
            if (obj != null && obj is Catalog<isbn, book> otherCatalog)
            {
                foreach(var item in otherCatalog.CatalogEntrys)
                {
                    if (!_catalog.ContainsKey(item.Key))
                    {
                        return false;
                    }

                    if (!item.Value.Equals(_catalog[item.Key]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }
    }
}
