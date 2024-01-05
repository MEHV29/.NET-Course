using Task6.DAL.Repositories.JSON.JSONEntities;
using Task6.DAL.Repositories.XML.XMLEntities;

namespace Task6
{
    public class Author : IComparable
    {
        string _firstName;
        string _lastName;
        string _dateBirth;

        const int MAX_LENGTH = 200;

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

        public Author(string firstName, string lastName, string dateBirth)
        {
            if(firstName.Length > MAX_LENGTH || lastName.Length > MAX_LENGTH)
            {
                throw new ArgumentException("firstName and lastName cannot have more than 200 characters");
            }

            _firstName = firstName;
            _lastName = lastName;
            _dateBirth = dateBirth;
        }

        public Author(string firstName, string lastName)
        {
            if (firstName.Length > MAX_LENGTH || lastName.Length > MAX_LENGTH)
            {
                throw new ArgumentException("firstName and lastName cannot have more than 200 characters");
            }

            _firstName = firstName;
            _lastName = lastName;
        }

        public Author(XMLAuthor xmlAuthor)
        {
            this._firstName = xmlAuthor.FirstName;
            this._lastName = xmlAuthor.LastName;
            this._dateBirth = xmlAuthor.DateBirth;
        }

        public Author(JSONAuthor jsonAuthor)
        {
            this._firstName = jsonAuthor.FirstName;
            this._lastName = jsonAuthor.LastName;
            this._dateBirth = jsonAuthor.DateBirth;
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
