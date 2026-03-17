using System;
using Xunit;
using OrbitalMechanics;

namespace OrbitalMechanicsTests
{
    public class EllipseTest
    {
        [Fact]
        public void ZeroEccentricitySemiMinorAxis()
        {
            Orbit orbit = new Orbit();
            orbit.SemiMajorAxis_m = 1000;
            orbit.Eccentricity = 0;

            Assert.Equal(orbit.SemiMajorAxis_m, orbit.SemiMinorAxis_m);
        }
        [Fact]
        public void ZeroEccentricityFocalDistance()
        {
            Orbit orbit = new Orbit();
            orbit.SemiMajorAxis_m = 1000;
            orbit.Eccentricity = 0;

            Assert.Equal(orbit.FocalDistance_m, 0);
        }
    }
}
