using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class AuthorsBuilder
    {
        public static void BuildAuthors(string field, List<Author> authorList, Regex regex, Regex regex2)
        {
            List<string> resultList = new List<string>();

            foreach (Match match in regex.Matches(field))
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
        }
    }
}
