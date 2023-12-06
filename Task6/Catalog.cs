using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Task6
{
    //XML Serialize requires that class to be public
    [XmlRoot("Catalog")]
    public class Catalog<isbn, book> : IXmlSerializable
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

        public IEnumerable<Book> GetByAuthor(Author author)
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
                    if (author != null)
                    {
                        if (authorBookCount.ContainsKey(author.FirstName + " " + author.LastName))
                        {
                            authorBookCount[author.FirstName + " " + author.LastName]++;
                        }
                        else
                        {
                            authorBookCount[author.FirstName + " " + author.LastName] = 1;
                        }
                    }
                }
            }
            return authorBookCount.OrderBy(author => author.Key).Select(pair => (pair.Key, pair.Value));
        }

        public IEnumerable<(Author, List<(string, Book)>)> GetBooksForAllAuthors()
        {
            Dictionary<Author, List<(string, Book)>> authorWithBooks = new Dictionary<Author, List<(string, Book)>>();

            foreach (var book in _catalog)
            {
                foreach (var author in (book.Value as Book).Authors)
                {
                    if (author != null)
                    {
                        if (authorWithBooks.ContainsKey(author))
                        {
                            authorWithBooks[author].Add((book.Key.ToString(), book.Value as Book));
                        }
                        else
                        {
                            authorWithBooks.Add(author, new List<(string, Book)> { (book.Key.ToString(), book.Value as Book) });
                        }
                    }
                }
            }
            return authorWithBooks.OrderBy(author => author.Key).Select(pair => (pair.Key, pair.Value));
        }

        public IEnumerable<(Author, List<(string, Book)>)> GetBookjsForAllAuthors()
        {
            Dictionary<Author, List<(string, Book)>> authorWithBooks = new Dictionary<Author, List<(string, Book)>>();

            foreach (var book in _catalog)
            {
                foreach (var author in (book.Value as Book).Authors)
                {
                    if (author != null)
                    {
                        if (authorWithBooks.ContainsKey(author))
                        {
                            authorWithBooks[author].Add((book.Key.ToString(), book.Value as Book));
                        }
                        else
                        {
                            authorWithBooks.Add(author, new List<(string, Book)> { (book.Key.ToString(), book.Value as Book) });
                        }
                    }
                }
            }
            return authorWithBooks.OrderBy(author => author.Key).Select(pair => (pair.Key, pair.Value));
        }
        public XmlSchema GetSchema() => null;

        public void ReadXml(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "CatalogEntry")
                {
                    isbn isbn = default(isbn);
                    book book = default(book);

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.EndElement && reader.Name == "CatalogEntry")
                            break;

                        if (reader.NodeType == XmlNodeType.Element)
                        {
                            switch (reader.Name)
                            {
                                case "ISBN":
                                    reader.Read();
                                    isbn = (isbn)Convert.ChangeType(reader.Value, typeof(isbn));
                                    break;

                                case "Book":
                                    var bookSerializer = new XmlSerializer(typeof(book));
                                    book = (book)bookSerializer.Deserialize(reader);
                                    break;
                            }
                        }
                    }

                    _catalog[isbn] = book;
                }
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            foreach (var item in _catalog)
            {
                writer.WriteStartElement("CatalogEntry");

                writer.WriteStartElement("ISBN");
                writer.WriteValue(item.Key.ToString());
                writer.WriteEndElement();

                var bookSerializer = new XmlSerializer(typeof(book));
                bookSerializer.Serialize(writer, item.Value);

                writer.WriteEndElement();
            }
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
