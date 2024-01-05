namespace Task6.AbstractFactory
{
    internal class UniquesBuilder
    {
        public static void BuildUniques(string field, List<string> uniqueFormats, char separator)
        {
            List<string> formats = field.Split(separator).ToList();
            
            foreach (string format in formats)
            {
                if (!uniqueFormats.Contains(format.Trim()))
                {
                    uniqueFormats.Add(format.Trim());
                }
            }
        }
    }
}
