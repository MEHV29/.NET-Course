using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Point
    {
        private int[] _coordinates = new int[3];

        public int X
        {
            get => _coordinates[0];
            set
            {
                _coordinates[0] = value;
            }
        }
        public int Y
        {
            get => _coordinates[1];
            set
            {
                _coordinates[1] = value;
            }
        }
        public int Z
        {
            get => _coordinates[2];
            set
            {
                _coordinates[2] = value;
            }
        }

        private double _mass;
        public double Mass
        {
            get => _mass;
            set
            {
                _mass = value < 0 ? 0 : value;
            }
        }

        public Point(int x, int y, int z, double mass)
        {
            X = x;
            Y = y;
            Z = z;
            Mass = mass;
        }

        public bool IsZero()
        {
            foreach (var coordinate in _coordinates)
            {
                if (coordinate != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public double DistanceBetweenPoints(Point point)
        {
            double distance;
            distance = Math.Sqrt(Math.Pow((point.X - this.X), 2) + Math.Pow((point.Y - this.Y), 2) + Math.Pow((point.Z - this.Z), 2));
            return distance;
        }
    }
}
