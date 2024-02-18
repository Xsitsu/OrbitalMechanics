using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics
{
    public class Offset
    {
        public double X
        {
            get;
            set;
        }
        public double Y
        {
            get;
            set;
        }

        public Offset() { }
        public Offset(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
