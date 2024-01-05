namespace Task6.AbstractFactory
{
    internal class PublishersBuilder
    {
        public static List<string> BuildPublishers(string field)
        {
            return field.Split(';').ToList();
        }
    }
}
