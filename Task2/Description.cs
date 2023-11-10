using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal abstract class Description
    {
        private string _textDescription;

        public string TextDescription
        {
            set { _textDescription = value;}
            get { return _textDescription; }
        }
    }
}
