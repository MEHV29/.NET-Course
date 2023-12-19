using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class EbookLibrayAbstractFactory : ILibrayAbstractFactory
    {
        List<string> _uniqueFormats;
        int isbnNull = 1;

        public Catalog<string, Book> CreateCatalog()
        {
            _uniqueFormats = new List<string>();
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
                    string id = string.Empty;
                    string title = string.Empty;
                    List<string> formats = new List<string>();

                    for (int i = 0; i < header.Length; i++)
                    {
                        switch (header[i])
                        {
                            case "title":
                                title = fields[i].Trim();
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
                            case "identifier":
                                id = fields[i].Trim();
                                break;
                            case "format":
                                formats = fields[i].Split(',').ToList();
                                foreach(string format in formats)
                                {
                                    if (!_uniqueFormats.Contains(format))
                                    {
                                        _uniqueFormats.Add(format);
                                    }
                                }
                                break;
                        }
                    }

                    EBook eBook = new EBook(title, authorList, id, formats);
                    catalog.Add(id, eBook);
                }
            }

            return catalog;
        }

        public List<string> CreatePressReleaseItems()
        {
            return _uniqueFormats;
        }
    }
}
