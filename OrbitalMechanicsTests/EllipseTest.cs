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
            Ellipse ellipse = new Ellipse();
            ellipse.SemiMajorAxis_l = 1000;
            ellipse.Eccentricity = 0;

            Assert.Equal(ellipse.SemiMajorAxis_l, ellipse.SemiMinorAxis_l);
        }
        [Fact]
        public void ZeroEccentricityFocalDistance()
        {
            Ellipse ellipse = new Ellipse();
            ellipse.SemiMajorAxis_l = 1000;
            ellipse.Eccentricity = 0;

            Assert.Equal(ellipse.FocalDistance_l, 0);
        }
    }
}
