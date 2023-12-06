using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class BookEntry
    {
        public string ISBN { get; set; }
        public Book Book { get; set; }
       
        public BookEntry(string iSBN, Book book)
        {
            ISBN = iSBN;
            Book = book;
        }
    }
}
