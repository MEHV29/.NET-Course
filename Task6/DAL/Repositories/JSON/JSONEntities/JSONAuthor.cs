using System.Text.Json.Serialization;

namespace Task6.DAL.Repositories.JSON.JSONEntities
{
    public class JSONAuthor
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateBirth { get; set; }
        [JsonConstructor]
        public JSONAuthor(string firstName, string lastName, string dateBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateBirth = dateBirth;
        }

        public JSONAuthor(Author author)
        {
            FirstName = author.FirstName;
            LastName = author.LastName;
            DateBirth = author.DateBirth;
        }
    }
}
