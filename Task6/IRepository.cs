using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal interface IRepository
    {
        void Serialize(Catalog<string, Book> catalog);
        Catalog<string, Book> Deserialize();
    }
}
