namespace Task5_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("Fantastic Mr Fox", "01-06-1970", new List<string> { "Roald Dahl"});
            Book book2 = new Book("Harry Potter and the Philosopher's Stone", "26-06-1997", new List<string> { "J.K Rowling" });
            Book book3 = new Book("Frankenstein", "01-01-1818", new List<string> { "Mary Shelley" });
            Book book4 = new Book("Animal Farm", "17-08-1945", new List<string> { "Mary Shelley" });
            Book book5 = new Book("Farm", "17-08-1900", new List<string> { "Mary Shelley" });

            Catalog<string, Book> catalog = new Catalog<string, Book>();
            catalog.Add("1234567890123", book1);
            catalog.Add("987-4-54-789012-3", book2);
            catalog.Add("4563217890123", book3);
            catalog.Add("4587861890123", book4);
            catalog.Add("1587861890123", book5);

            Book bookCatalog = catalog["987-4-54-789012-3"];

            foreach(var book in catalog.OrderAlphabetically())
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine();

            foreach (var book in catalog.GetByAuthor("Mary Shelley"))
            {
                Console.WriteLine(book.Title);
            }

            Console.WriteLine();

            foreach (var author in catalog.GetNumberBooksForAllAuthors())
            {
                Console.WriteLine(author);
            }
        }
    }
}