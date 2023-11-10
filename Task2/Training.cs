using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Training : Description
    {
        private Lesson[] _content;
        private int _sizeContent;

        public Training(string textDescription, Lesson[] content)
        {
            this.TextDescription = textDescription;
            this._content = content;
            this._sizeContent = content.Length;
        }

        public Training(string textDescription)
        {
            this.TextDescription = textDescription;
        }

        public Training(Lesson[] content)
        {
            this._content = content;
        }

        public void Add(Lesson obj)
        {
            Lesson[] tempContent = new Lesson[++_sizeContent];
            if (_sizeContent > 1)
            {
                for (int i = 0; i < _sizeContent - 1; i++)
                {
                    tempContent[i] = this._content[i];
                }
            }
            tempContent[_sizeContent - 1] = obj;
            this._content = tempContent;
        }

        public bool IsPractical()
        {
            foreach (Lesson obj in _content)
            {
                if (obj is Lecture)
                {
                    return false;
                }
            }

            return true;
        }

        public Training Clone()
        {
            Lesson[] _cloneContent = new Lesson[_content.Length];
            for(int i = 0; i < _content.Length; i++)
            {
                _cloneContent[i] = _content[i].Clone();
            }
            
            return new Training(TextDescription, _cloneContent);
        }
    }
}
