using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using OrbitalMechanics.Solver;

namespace OrbitalMechanics
{
    public class CircleSolver : ISolver
    {
        public override double GetPercentComplete(double centerMass_kg, Orbit orbit, double elapsedTime_sec)
        {
            double period_sec = CalculateOrbitalPeriod_sec(centerMass_kg, orbit);
            double percent = elapsedTime_sec / period_sec;
            percent %= 1;
            return percent;
        }
        public override double GetOrbitDistance_m(Orbit orbit, double percentCompleted)
        {
            return orbit.SemiMajorAxis_m;
        }
    }
}
