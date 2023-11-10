using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal abstract class Lesson : Description
    {
        public abstract Lesson Clone();
    }
}
