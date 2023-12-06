using System.Text.Json;

namespace Task6
{
    internal class JSONRepository : IRepository
    {
        Catalog<string, Book> _catalog;
        public Catalog<string, Book> Deserialize()
        {
            
            Catalog<string, Book> catalog = new Catalog<string, Book>();

            foreach (var authorWithBooks in _catalog.GetBooksForAllAuthors())
            {
                string jsonString = File.ReadAllText($"{authorWithBooks.Item1.FirstName + "_" + authorWithBooks.Item1.LastName}.json");
                AuthorEntry authorEntry = JsonSerializer.Deserialize<AuthorEntry>(jsonString)!;
                authorEntry.Books.ForEach((book) =>
                {
                    catalog.Add(book.ISBN, book.Book);
                });
            }

            return catalog;
        }

        public void Serialize(Catalog<string, Book> catalog)
        {
            _catalog = catalog;
            var options = new JsonSerializerOptions { WriteIndented = true };
            foreach (var authorWithBooks in catalog.GetBooksForAllAuthors())
            {
                List<BookEntry> bookEntries = new List<BookEntry>();
                authorWithBooks.Item2.ForEach(item2 =>
                {
                    BookEntry bookEntry = new BookEntry(item2.Item1, item2.Item2);
                    bookEntries.Add(bookEntry);
                });

                AuthorEntry entry = new AuthorEntry(authorWithBooks.Item1.FirstName, authorWithBooks.Item1.LastName, authorWithBooks.Item1.DateBirth, bookEntries);
                string jsonString = JsonSerializer.Serialize(entry, options);
                File.WriteAllText($"{authorWithBooks.Item1.FirstName + "_" + authorWithBooks.Item1.LastName}.json", jsonString);
            }
        }
    }
}
