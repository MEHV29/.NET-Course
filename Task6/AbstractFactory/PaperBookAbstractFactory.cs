using Microsoft.Extensions.FileSystemGlobbing.Internal;
using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class PaperBookAbstractFactory : ILibrayAbstractFactory
    {
        public Catalog<string, Book> CreateCatalog()
        {
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
                    string title;
                    string publicDate;
                    List<Author> authorList = new List<Author>();   

                    for (int i = 0; i < header.Length; i++)
                    {
                        //string columnName = header[i];
                        //string value = fields[i];
                        string value;
                        switch (header[i])
                        {
                            case "creator":
                                List<string> resultList = new List<string>();

                                string pattern = @"[^,]+(?:,\s+[^,]+)*(?:,\s+\d{4}-\d{4})?";
                                Regex regex = new Regex(pattern);

                                foreach (Match match in regex.Matches(fields[i]))
                                {
                                    resultList.Add(match.Value.Trim());
                                }

                                foreach (string item in resultList)
                                {
                                    string[] subItems = item.Split(',');
                                }
                                break;
                            case "publicdate":
                                value = fields[i];
                                break;
                            case "related-external-id":
                                value = fields[i];
                                break;
                            case "title":
                                value = fields[i];
                                break;
                            case "publisher":
                                value = fields[i];
                                break;
                        }
                        //PaperBook paperBook = new PaperBook("assdas", "01-06-2001", new List<Author> { author6 }, isbns, "Scholastic Inc.");
                    }

                    // Add any further processing logic here
                }
            }

            return null;
        }

        public List<string> CreatePressReleaseItems()
        {
            return null;
        }
    }
}
