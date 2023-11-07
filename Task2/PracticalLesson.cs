using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class PracticalLesson
    {
        private string textDescription;
        private string linkToTaskCondition;
        private string linkToSolution;

        public PracticalLesson(string textDescription, string linkToTaskCondition, string linkToSolution)
        {
            this.textDescription = textDescription;
            this.linkToTaskCondition = linkToSolution;
            this.linkToSolution = linkToTaskCondition;
        }
    }
}
