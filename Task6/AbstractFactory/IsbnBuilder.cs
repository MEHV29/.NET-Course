using System.Text.RegularExpressions;

namespace Task6.AbstractFactory
{
    internal class IsbnBuilder
    {
        public static void BuildIsbn(string field, List<string> isbns, Regex regexIsbn)
        {
            MatchCollection matches = regexIsbn.Matches(field);

            foreach (Match match in matches)
            {
                isbns.Add(match.Value.Substring(5));
            }
        }
    }
}
