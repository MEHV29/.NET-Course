using System.Text.Json.Serialization;
using Task6.DAL.Repositories.XML.XMLEntities;

namespace Task6
{
    public class Author : IComparable
    {
        string _firstName;
        string _lastName;
        string _dateBirth;

        public string FirstName
        {
            get => _firstName;
        }

        public string LastName
        {
            get => _lastName;
        }

        public string DateBirth
        {
            get => _dateBirth;
        }

        [JsonConstructor]
        public Author(string firstName, string lastName, string dateBirth)
        {
            _firstName = firstName.Substring(0, Math.Min(firstName.Length, 200));
            _lastName = lastName.Substring(0, Math.Min(lastName.Length, 200));
            _dateBirth = dateBirth;
        }

        public Author(XMLAuthor xmlAuthor)
        {
            this._firstName = xmlAuthor.FirstName;
            this._lastName = xmlAuthor.LastName;
            this._dateBirth = xmlAuthor.DateBirth;
        }

        public override bool Equals(object obj)
        {
            if (obj is not Author otherAuthor)
                return false;

            return _firstName == otherAuthor._firstName &&
                   _lastName == otherAuthor._lastName &&
                   _dateBirth == otherAuthor._dateBirth;
        }

        public int CompareTo(object? obj)
        {
            return _firstName.CompareTo((obj as Author).FirstName);
        }
    }
}
