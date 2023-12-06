namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author author1 = new Author("Mary", "Shelley", "30-08-1797");
            Author author2 = new Author("Roald", "Dahl", "13-09-1916");
            Author author3 = new Author("J.K", "Rowling", "31-07-1965");
            Author author4 = new Author("Peter", "Straub", "02-04-1943");
            Author author5 = new Author("Stephen", "King", "21-09-1947");
            Author author6 = new Author("George", "Orwell", "25-06-1903");

            Book book1 = new Book("Fantastic Mr Fox", "01-06-1970", new List<Author> { author2 });
            Book book2 = new Book("Harry Potter and the Philosopher's Stone", "26-06-1997", new List<Author> { author3 });
            Book book3 = new Book("Frankenstein", "01-01-1818", new List<Author> { author1 });
            Book book4 = new Book("Animal Farm", "17-08-1945", new List<Author> { author6 });
            Book book5 = new Book("The Talisman", "08-11-1984", new List<Author> { author4, author5 });
            Book book6 = new Book("IT", "15-09-1986", new List<Author> { author5 });

            Catalog<string, Book> catalog = new Catalog<string, Book>();
            catalog.Add("978-0-14-241034-9", book1);
            catalog.Add("978-0-74-753274-3", book2);
            catalog.Add("9788476727737", book3);
            catalog.Add("9781951151881", book4);
            //catalog.Add("9781951151881", book5);
            catalog.Add("9780670691999", book5);
            catalog.Add("9786073814003", book6);
            
            IRepository repositoryXML = new XMLRepository();
            repositoryXML.Serialize(catalog);
            Catalog<string, Book> catalogXml = repositoryXML.Deserialize();
            Console.WriteLine($"Is equals XML to Original Object? {catalog.Equals(catalogXml)}\n");
            
            IRepository repositoryJSON = new JSONRepository();
            repositoryJSON.Serialize(catalog);
            Catalog<string, Book> catalogJSON = repositoryJSON.Deserialize();
            Console.WriteLine($"Is equals JSON to Original Object? {catalog.Equals(catalogJSON)}");
        }
    }
}