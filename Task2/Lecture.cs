using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Lecture : Lesson
    {
        private string _topic;

        public string Topic
        {
            get { return _topic; }
        }

        public Lecture(string textDescription, string topic)
        {
            this.TextDescription = textDescription;
            this._topic = topic;
        }

        public override Lecture Clone()
        {
            string textDescription = this.TextDescription;
            string topic = this.Topic;
            return new Lecture(textDescription, topic);
        }
    }
}
