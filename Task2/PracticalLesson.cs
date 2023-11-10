using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class PracticalLesson : Lesson
    {
        private string _linkToTaskCondition;
        private string _linkToSolution;

        public string LinkToTaskCondition
        {
            get { return _linkToTaskCondition; }
        }

        public string LinkToSolution
        {
            get { return _linkToSolution; }
        }

        public PracticalLesson(string textDescription, string linkToTaskCondition, string linkToSolution)
        {
            this.TextDescription = textDescription;
            this._linkToTaskCondition = linkToSolution;
            this._linkToSolution = linkToTaskCondition;
        }

        public override PracticalLesson Clone()
        {
            string textDescription = this.TextDescription;
            string linkToTaskCondition = this.LinkToTaskCondition;
            string linkToSolution = this.LinkToSolution;
            return new PracticalLesson(textDescription, linkToTaskCondition, linkToSolution);
        }
    }
}
