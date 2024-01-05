namespace Task6.AbstractFactory
{
    internal class FormatsBuilder
    {
        public static List<string> BuildFormats(string field)
        {
            return field.Split(',').ToList();
        }
    }
}
