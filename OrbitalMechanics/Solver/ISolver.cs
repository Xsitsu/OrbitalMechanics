using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics.Solver
{
    public abstract class ISolver
    {
        public double CalculateOrbitalPeriod_sec(double centerMass_kg, Orbit orbit)
        {
            double SMA3 = orbit.SemiMajorAxis_m * orbit.SemiMajorAxis_m * orbit.SemiMajorAxis_m;

            double top = (4 * Numbers.PISquared * SMA3);
            double bottom = (Numbers.G * centerMass_kg);

            double period = System.Math.Sqrt(top / bottom);

            return period;
        }
        public abstract double GetPercentComplete(double centerMass_kg, Orbit orbit, double atTime_sec);
        public abstract double GetOrbitDistance_m(Orbit orbit, double percentCompleted);
    }
}
