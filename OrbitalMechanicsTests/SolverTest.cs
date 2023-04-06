using System;
using Xunit;
using OrbitalMechanics;
using OrbitalMechanics.Solver;

namespace OrbitalMechanicsTests
{
    public class SolverTest
    {
        // TODO: Come up with better solution and maybe improve
        // precision with calculations while at it
        static int SIGFIG_CHECK = 10000;
        private int SIGFIG_Round(double number)
        {
            return ((int)(number/ SIGFIG_CHECK)) * SIGFIG_CHECK;
        }

        [Fact]
        public void OrbitalPeriodEarthSun()
        {
            Orbit earthOrbit = CreateEarthOrbit();
            ISolver solver = new CircleSolver();

            double calculatedPeriod = solver.CalculateOrbitalPeriod_sec(Numbers.SolarMassToKG, earthOrbit);
            double expectedPeriod = Numbers.YearToSeconds;

            Assert.Equal(SIGFIG_Round(expectedPeriod), SIGFIG_Round(calculatedPeriod));
        }
        //[Fact]
        public void OrbitalPeriodMoonEarth()
        {
            Orbit moonOrbit = CreateMoonOrbit();
            ISolver solver = new CircleSolver();

            double calculatedPeriod = solver.CalculateOrbitalPeriod_sec(Numbers.EarthMassToKGs, moonOrbit);
            double expectedPeriod = 27.321661 * Numbers.DayToSeconds;

            Assert.Equal(SIGFIG_Round(expectedPeriod), SIGFIG_Round(calculatedPeriod));
        }

        [Fact]
        public void PercentCompleteCircle_Zero()
        {
            Orbit earthOrbit = CreateEarthOrbit();
            ISolver solver = new CircleSolver();

            double period_sec = solver.CalculateOrbitalPeriod_sec(Numbers.SolarMassToKG, earthOrbit);

            double calculated = solver.GetPercentComplete(Numbers.SolarMassToKG, earthOrbit, 0);
            double expected = 0.0;

            Assert.Equal(expected, calculated);
        }
        [Fact]
        public void PercentCompleteCircle_Half()
        {
            Orbit earthOrbit = CreateEarthOrbit();
            ISolver solver = new CircleSolver();

            double period_sec = solver.CalculateOrbitalPeriod_sec(Numbers.SolarMassToKG, earthOrbit);

            double calculated = solver.GetPercentComplete(Numbers.SolarMassToKG, earthOrbit, 0.5 * period_sec);
            double expected = 0.5;

            Assert.Equal(expected, calculated);
        }
        [Fact]
        public void PercentCompleteCircle_Full()
        {
            Orbit earthOrbit = CreateEarthOrbit();
            ISolver solver = new CircleSolver();

            double period_sec = solver.CalculateOrbitalPeriod_sec(Numbers.SolarMassToKG, earthOrbit);

            double calculated = solver.GetPercentComplete(Numbers.SolarMassToKG, earthOrbit, 1 * period_sec);
            double expected = 0.0;

            Assert.Equal(expected, calculated);
        }

        private Orbit CreateEarthOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 149598023.0 * Numbers.KMToM,
                Eccentricity = 0.0167086,
            };
        }
        private Orbit CreateMoonOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 384399 * Numbers.KMToM,
                Eccentricity = 0.0549,
            };
        }
    }
}
