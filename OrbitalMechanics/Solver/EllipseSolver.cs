using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics.Solver
{
    public class EllipseSolver : ISolver
    {
        public override double GetOrbitAngle_deg(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            return CalculateTrueAnomaly(centerMass_kg, orbit, atTime_sec);
        }
        public override Offset CalculateOffset_m(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            double eccentricAnomaly_deg = CalculateEccentricAnomaly(centerMass_kg, orbit, atTime_sec);
            double x = Math.Cos(eccentricAnomaly_deg) + orbit.SemiMajorAxis_m - orbit.Periapsis_m;
            double y = Math.Sin(eccentricAnomaly_deg);
            return new Offset(x, y);
        }
    }
}
