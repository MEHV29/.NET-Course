using System.Text.Json;
using Task6.DAL.Interfaces;
using Task6.DAL.Repositories.JSON.JSONEntities;

namespace Task6.DAL.Repositories.JSON
{
    internal class JSONReader : IRespositoryRead
    {
        public Catalog<string, Book> GetCatalog()
        {
            throw new NotImplementedException();
        }

        public Catalog<string, Book> GetCatalogByAuthors(Catalog<string, Book> catalog)
        {
            Catalog<string, Book> catalogJSON = new Catalog<string, Book>();

            foreach (var authorWithBooks in catalog.GetBooksForAllAuthors())
            {
                string jsonString = File.ReadAllText($"{authorWithBooks.Item1.FirstName + "_" + authorWithBooks.Item1.LastName}.json");
                AuthorEntry authorEntry = JsonSerializer.Deserialize<AuthorEntry>(jsonString)!;
                authorEntry.Books.ForEach((book) =>
                {
                    catalogJSON.Add(book.ISBN, new Book(book.Book));
                });
            }

            return catalogJSON;
        }
    }
}
