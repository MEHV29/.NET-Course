using Microsoft.VisualBasic.FileIO;
using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class EbookLibrayAbstractFactory : ILibrayAbstractFactory
    {
        List<string> _uniqueFormats;
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
                    string id = string.Empty;
                    string title = string.Empty;
                    List<string> formats = new List<string>();

                    string pattern = @"[^,]+(?:,\s+[^,]+)*(?:,\s+\d{4}-\d{4})?";
                    string pattern2 = @"\d+";
                    Regex regex = new Regex(pattern);
                    Regex regex2 = new Regex(pattern2);

                    for (int i = 0; i < header.Length; i++)
                    {
                        switch (header[i])
                        {
                            case "title":
                                title = TitleBuilder.BuildTitle(fields[i]);
                                break;
                            case "creator":
                                AuthorsBuilder.BuildAuthors(fields[i], authorList, regex, regex2);
                                break;
                            case "identifier":
                                id = IdBuilder.BuildId(fields[i]);
                                break;
                            case "format":
                                formats = FormatsBuilder.BuildFormats(fields[i]);
                                break;
                        }
                    }

                    EBook eBook = new EBook(title, authorList, id, formats);
                    catalog.Add(id, eBook);
                }
            }

            return catalog;
        }

        public List<string> CreatePressReleaseItems(string filePath)
        {
            if (_uniqueFormats == null)
            {
                _uniqueFormats = new List<string>();

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
                                case "format":
                                    UniquesBuilder.BuildUniques(fields[i], _uniqueFormats, ',');
                                    break;
                            }
                        }
                    }
                }

                return _uniqueFormats;
            }
            else
            {
                return _uniqueFormats;
            }
        }
    }
}
