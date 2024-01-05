namespace Task6.AbstractFactory
{
    internal class TitleBuilder
    {
        public static string BuildTitle(string field)
        {
            return field.Trim();
        }
    }
}
