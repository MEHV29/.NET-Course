using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Training
    {
        private string textDescription;
        private object[] content;
        private int sizeContent;

        public Training(string textDescription, object[] content)
        {
            this.textDescription = textDescription;
            this.content = content;
            this.sizeContent = content.Length;
        }

        public Training(string textDescription)
        {
            this.textDescription = textDescription;
        }

        public Training(object[] content)
        {
            this.content = content;
        }

        public void Add(object obj)
        {
            object[] tempContent = new object[++sizeContent];
            if (sizeContent > 1)
            {
                for(int i = 0; i < sizeContent - 1; i++)
                {
                    tempContent[i] = this.content[i];
                }
            }
            tempContent[sizeContent - 1] = obj;
            this.content = tempContent;
        }

        public bool IsPractical()
        {
            foreach (object obj in content)
            {
                if (obj is Lecture) return false;
            }

            return true;
        }

        public Training Clone()
        {
            return new Training(textDescription, content);
        }
    }
}
