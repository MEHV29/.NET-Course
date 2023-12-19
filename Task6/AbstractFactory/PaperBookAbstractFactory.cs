using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class PaperBookAbstractFactory : ILibrayAbstractFactory
    {
        List<string> _uniquePublishers;
        int isbnNull = 1;

        public Catalog<string, Book> CreateCatalog()
        {
            _uniquePublishers = new List<string>();
            string filePath = "books_info.csv";
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

                    for (int i = 0; i < header.Length; i++)
                    {
                        switch (header[i])
                        {
                            case "title":
                                title = fields[i].Trim();
                                break;
                            case "publicdate":
                                publicationDate = fields[i].Trim();
                                break;
                            case "creator":
                                List<string> resultList = new List<string>();

                                string pattern = @"[^,]+(?:,\s+[^,]+)*(?:,\s+\d{4}-\d{4})?";
                                string pattern2 = @"\d+";
                                Regex regex = new Regex(pattern);
                                Regex regex2 = new Regex(pattern2);

                                foreach (Match match in regex.Matches(fields[i]))
                                {
                                    resultList.Add(match.Value.Trim());
                                }

                                foreach (string item in resultList)
                                {
                                    string[] subItems = item.Split(',');
                                    if (subItems.Length == 1)
                                    {
                                        subItems = item.Split(' ');
                                    }

                                    Author author;

                                    if (subItems.Length == 3 && regex2.IsMatch(subItems[2]))
                                    {
                                        author = new Author(subItems[1], subItems[0], subItems[2].Substring(0, 5));
                                    }
                                    else if (subItems.Length == 1)
                                    {
                                        author = new Author(subItems[0], string.Empty, string.Empty);
                                    }
                                    else if (regex2.IsMatch(subItems[1]))
                                    {
                                        author = new Author(subItems[0], string.Empty, string.Empty);
                                    }
                                    else
                                    {
                                        author = new Author(subItems[1], subItems[0], string.Empty);
                                    }

                                    authorList.Add(author);
                                }
                                break;
                            case "related-external-id":
                                string patternIsbn = @"isbn:\d+";

                                Regex regexIsbn = new Regex(patternIsbn);
                                MatchCollection matches = regexIsbn.Matches(fields[i]);

                                foreach (Match match in matches)
                                {
                                    isbns.Add(match.Value.Substring(5));
                                }
                                break;
                            case "publisher":
                                string[] publishersArray = fields[i].Split(';');

                                foreach (string item in publishersArray)
                                {
                                    if (!_uniquePublishers.Contains(item.Trim()))
                                    {
                                        _uniquePublishers.Add(item.Trim());
                                    }

                                    publishers.Add(item.Trim());
                                }
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

        public List<string> CreatePressReleaseItems()
        {
            return _uniquePublishers;
        }
    }
}
