using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Point
    {
        private int[] coordinates = new int[3];

        public int X
        {
            get => coordinates[0];
            set
            {
                coordinates[0] = value;
            }
        }
        public int Y
        {
            get => coordinates[1];
            set
            {
                coordinates[1] = value;
            }
        }
        public int Z
        {
            get => coordinates[2];
            set
            {
                coordinates[2] = value;
            }
        }

        private float mass;
        public float Mass
        {
            get => mass;
            set
            {
                mass = value < 0 ? 0 : value;
            }
        }

        public bool IsZero()
        {
            foreach (var coordinate in coordinates)
            {
                if (coordinate != 0) return false;
            }

            return true;
        }

        public float DistanceBetweenPoints(Point point)
        {
            float distance;
            distance = (float)Math.Sqrt(Math.Pow((point.X - this.X), 2) + Math.Pow((point.Y - this.Y), 2) + Math.Pow((point.Z - this.Z), 2));
            return distance;
        }
    }
}
