namespace Task6.AbstractFactory
{
    internal class IdBuilder
    {
        public static string BuildId(string field)
        {
            return "https://archive.org/details/" + field.Trim();
        }
    }
}
