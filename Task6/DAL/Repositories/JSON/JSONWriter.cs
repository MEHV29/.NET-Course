using System.Text.Json;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories.JSON.JSONEntities;

namespace Task6.DAL.Repositories.JSON
{
    internal class JSONWriter : IRepositoryWrite
    {
        public void SaveCatalog(Catalog<string, Book> catalog)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            foreach (var authorWithBooks in catalog.GetBooksForAllAuthors())
            {
                List<BookEntry> bookEntries = new List<BookEntry>();
                authorWithBooks.Item2.ForEach(item2 =>
                {
                    BookEntry bookEntry = new BookEntry(item2.Item1, new JSONBook(item2.Item2));
                    bookEntries.Add(bookEntry);
                });

                AuthorEntry entry = new AuthorEntry(authorWithBooks.Item1.FirstName, authorWithBooks.Item1.LastName, authorWithBooks.Item1.DateBirth, bookEntries);
                string jsonString = JsonSerializer.Serialize(entry, options);
                File.WriteAllText($"{authorWithBooks.Item1.FirstName + "_" + authorWithBooks.Item1.LastName}.json", jsonString);
            }
        }
    }
}
