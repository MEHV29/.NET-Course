using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task6
{
    internal class AuthorEntry
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateBirth { get; set; }

        public List<BookEntry> Books { get; set; }

        public AuthorEntry(string firstname, string lastname, string dateBirth, List<BookEntry> books)
        {
            FirstName = firstname;
            LastName = lastname;
            DateBirth = dateBirth;
            Books = books;
        }
    }
}
