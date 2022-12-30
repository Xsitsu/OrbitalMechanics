using System;
using Xunit;
using OrbitalMechanics;

namespace OrbitalMechanicsTests
{
    public class OrbitTest
    {
        [Fact]
        public void ZeroEccentricityPeriapsis()
        {
            Orbit orbit = new Orbit();
            orbit.SemiMajorAxis_m = 1000;
            orbit.Eccentricity = 0;

            Assert.Equal(orbit.SemiMajorAxis_m, orbit.Periapsis_m);
        }
        [Fact]
        public void ZeroEccentricityApoapsis()
        {
            Orbit orbit = new Orbit();
            orbit.SemiMajorAxis_m = 1000;
            orbit.Eccentricity = 0;

            Assert.Equal(orbit.SemiMajorAxis_m, orbit.Apoapsis_m);
        }
    }
}
