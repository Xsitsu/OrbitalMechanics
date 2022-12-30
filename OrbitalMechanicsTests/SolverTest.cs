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

        [Fact]
        public void OrbitalPeriodEarthSun()
        {
            Orbit earthOrbit = CreateEarthOrbit();
            ISolver solver = new TwoBodySolver();

            double calculatedPeriod = solver.CalculateOrbitalPeriod_sec(Numbers.SolarMassToKG, earthOrbit);
            double expectedPeriod = Numbers.YearToSeconds;

            int useExpected = (int)(expectedPeriod / SIGFIG_CHECK);
            int useCalculated = (int)(calculatedPeriod / SIGFIG_CHECK);
            Assert.Equal(useExpected, useCalculated);
        }
        [Fact]
        public void OrbitalPeriodMoonEarth()
        {
            Orbit moonOrbit = CreateMoonOrbit();
            ISolver solver = new TwoBodySolver();

            double calculatedPeriod = solver.CalculateOrbitalPeriod_sec(Numbers.EarthMassToKGs, moonOrbit);
            double expectedPeriod = 27.321661 * Numbers.DayToSeconds;

            int useExpected = (int)(expectedPeriod / SIGFIG_CHECK);
            int useCalculated = (int)(calculatedPeriod / SIGFIG_CHECK);
            Assert.Equal(useExpected, useCalculated);
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
