using System;
using Xunit;
using OrbitalMechanics;
using OrbitalMechanics.Solver;
using OrbitalMechanicsTests;

namespace OrbitalMechanicsTests
{
    public class SolverTest
    {
        // TODO: Come up with better solution and maybe improve
        // precision with calculations while at it
        private double SIGFIG_Round(double number, int number_figures)
        {
            int SIGFIG_CHECK = (int)Math.Pow(10, number_figures);
            Console.WriteLine("SIGFIG_CHECK:", SIGFIG_CHECK);
            return ((int)(number/ SIGFIG_CHECK)) * SIGFIG_CHECK;
        }

        private void CompareEqual(double x, double y, int sig_figs)
        {
            Assert.Equal(SIGFIG_Round(x, sig_figs), SIGFIG_Round(y, sig_figs));
        }

        [Fact]
        public void CircleOffsetIsNonZero()
        {
            Orbit orbit = PlanetOrbits.CreateEarthOrbit();
            ISolver solver = new CircleSolver();
            Offset offset = solver.CalculateOffset_m(1, orbit, 1);

            Assert.NotEqual(offset.X + offset.Y, 0);
        }
        [Fact]
        public void CircleOffsetIsGreaterThanZero()
        {
            Orbit orbit = PlanetOrbits.CreateEarthOrbit();
            ISolver solver = new CircleSolver();
            Offset offset = solver.CalculateOffset_m(1, orbit, 1);

            Assert.True((offset.X + offset.Y) > 0);
        }
        [Fact]
        public void CircleOffsetStartsAtCorrectSpot()
        {
            Orbit orbit = new Orbit()
            {
                SemiMajorAxis_m = 10,
                Eccentricity = 0,
            };
            ISolver solver = new CircleSolver();
            Offset offset = solver.CalculateOffset_m(1, orbit, 0);

            Assert.Equal(orbit.SemiMajorAxis_m, offset.X);
            Assert.NotEqual(orbit.SemiMajorAxis_m, offset.Y);
            Assert.Equal(0, offset.Y);
        }
        [Fact]
        public void EllipseOffsetIsNonZero()
        {
            Orbit orbit = PlanetOrbits.CreateEarthOrbit();
            ISolver solver = new EllipseSolver();
            Offset offset = solver.CalculateOffset_m(1, orbit, 1);

            Assert.NotEqual(offset.X + offset.Y, 0);
        }
        [Fact]
        public void EllipseOffsetIsGreaterThanZero()
        {
            Orbit orbit = PlanetOrbits.CreateEarthOrbit();
            ISolver solver = new EllipseSolver();
            Offset offset = solver.CalculateOffset_m(1, orbit, 1);

            Assert.True((offset.X + offset.Y) > 0);
        }
        [Fact]
        public void EllipseOffsetStartsAtCorrectSpot()
        {
            Orbit orbit = new Orbit()
            {
                SemiMajorAxis_m = 10,
                Eccentricity = 0,
            };
            ISolver solver = new EllipseSolver();
            Offset offset = solver.CalculateOffset_m(1, orbit, 0);

            Assert.Equal(orbit.SemiMajorAxis_m, offset.X);
            Assert.NotEqual(orbit.SemiMajorAxis_m, offset.Y);
            Assert.Equal(0, offset.Y);
        }

        //[Fact]
        public void OrbitalPeriodEarthSun()
        {
            Orbit earthOrbit = PlanetOrbits.CreateEarthOrbit();
            ISolver solver = new CircleSolver();

            double calculatedPeriod = solver.CalculateOrbitalPeriod_sec(Numbers.SolarMassToKG, earthOrbit);
            double expectedPeriod = Numbers.YearToSeconds;

            CompareEqual(expectedPeriod, calculatedPeriod, 80);
        }
        //[Fact]
        public void OrbitalPeriodMoonEarth()
        {
            Orbit moonOrbit = PlanetOrbits.CreateMoonOrbit();
            ISolver solver = new CircleSolver();

            double calculatedPeriod = solver.CalculateOrbitalPeriod_sec(Numbers.EarthMassToKGs, moonOrbit);
            double expectedPeriod = 27.321661 * Numbers.DayToSeconds;

            CompareEqual(expectedPeriod, calculatedPeriod, 6);
        }

        //[Fact]
        public void TestMercury()
        {
            Orbit orbit = PlanetOrbits.CreateMercuryOrbit();
            CompareEqual(orbit.SemiMinorAxis_m, 0.3787, 80);
        }

    }
}
