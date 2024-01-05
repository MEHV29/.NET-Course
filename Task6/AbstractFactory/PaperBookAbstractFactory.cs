using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class PaperBookAbstractFactory : ILibrayAbstractFactory
    {
        List<string> _uniquePublishers;
        //this isbn is assigned to books with null isbn in the file and cannot be null because is the key in the dictionary catalog
        //it's auto increment after every assign
        int isbnNull = 1;

        public Catalog<string, Book> CreateCatalog(string filePath)
        {
            Catalog<string, Book> catalog = new Catalog<string, Book>();

            if (!File.Exists(filePath))
            {
                throw new Exception("File is not in the correct path");
            }

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;

                string[] header = parser.ReadFields();
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    List<Author> authorList = new List<Author>();
                    string publicationDate = string.Empty;
                    List<string> isbns = new List<string>();
                    List<string> publishers = new List<string>();
                    string title = string.Empty;
                    bool isbnIsNull = false;

                    string pattern = @"[^,]+(?:,\s+[^,]+)*(?:,\s+\d{4}-\d{4})?";
                    string pattern2 = @"\d+";
                    Regex regex = new Regex(pattern);
                    Regex regex2 = new Regex(pattern2);

                    string patternIsbn = @"isbn:\d+";
                    Regex regexIsbn = new Regex(patternIsbn);

                    for (int i = 0; i < header.Length; i++)
                    {
                        switch (header[i])
                        {
                            case "title":
                                title = TitleBuilder.BuildTitle(fields[i]);
                                break;
                            case "publicdate":
                                publicationDate = PublicationDateBuilder.BuildPublicationDate(fields[i]);
                                break;
                            case "creator":
                                AuthorsBuilder.BuildAuthors(fields[i], authorList, regex, regex2);
                                break;
                            case "related-external-id":
                                IsbnBuilder.BuildIsbn(fields[i], isbns, regexIsbn);
                                break;
                            case "publisher":
                                publishers = PublishersBuilder.BuildPublishers(fields[i]);
                                break;
                        }
                    }

                    if (isbns.Count == 0)
                    {
                        isbns.Add(isbnNull.ToString());
                        isbnNull++;
                        isbnIsNull = true;
                    }
                    
                    PaperBook paperBook = new PaperBook(title, publicationDate, authorList, isbns, publishers, isbnIsNull);

                    if (catalog.CatalogEntrys.ContainsKey(paperBook.Isbns.FirstOrDefault()))
                    {
                        catalog.Add(paperBook.Isbns[2], paperBook);
                    }
                    else
                    {
                        catalog.Add(paperBook.Isbns.FirstOrDefault(), paperBook);
                    }
                }
            }

            return catalog;
        }

        public List<string> CreatePressReleaseItems(string filePath)
        {
            if (_uniquePublishers == null)
            {
                _uniquePublishers = new List<string>();

                if (!File.Exists(filePath))
                {
                    throw new Exception("File is not in the correct path");
                }

                using (TextFieldParser parser = new TextFieldParser(filePath))
                {
                    parser.SetDelimiters(",");
                    parser.HasFieldsEnclosedInQuotes = true;

                    string[] header = parser.ReadFields();
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();

                        for (int i = 0; i < header.Length; i++)
                        {
                            switch (header[i])
                            {
                                case "publisher":
                                    UniquesBuilder.BuildUniques(fields[i], _uniquePublishers, ';');
                                    break;
                            }
                        }
                    }
                }

                return _uniquePublishers;
            }
            else
            {
                return _uniquePublishers;
            }
        }
    }
}
