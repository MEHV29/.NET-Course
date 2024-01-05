namespace Task6.AbstractFactory
{
    internal class PublicationDateBuilder
    {
        public static string BuildPublicationDate(string field)
        {
            return field.Trim();
        }
    }
}
