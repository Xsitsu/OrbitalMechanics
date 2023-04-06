using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics.Solver
{
    public class EllipseSolver : ISolver
    {
        public override double GetPercentComplete(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            throw new NotImplementedException();
        }
        public override double GetOrbitDistance_m(Orbit orbit, double percentCompleted)
        {
            throw new NotImplementedException();
        }
    }
}
