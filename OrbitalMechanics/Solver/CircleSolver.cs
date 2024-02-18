using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using OrbitalMechanics.Solver;

namespace OrbitalMechanics.Solver
{
    public class CircleSolver : ISolver
    {
        public override double GetOrbitDistance_m(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            return orbit.SemiMajorAxis_m;
        }
        public override double GetOrbitAngle_deg(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            return CalculateMeanAnomaly(centerMass_kg, orbit, atTime_sec);
        }
        public override Offset CalculateOffset_m(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            double meanAnomaly_deg = CalculateMeanAnomaly(centerMass_kg, orbit, atTime_sec);
            double x = Math.Cos(meanAnomaly_deg) * orbit.SemiMajorAxis_m;
            double y = Math.Sin(meanAnomaly_deg) * orbit.SemiMajorAxis_m;
            return new Offset(x, y);
        }
    }
}
