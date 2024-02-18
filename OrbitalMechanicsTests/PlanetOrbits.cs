using System;
using System.Collections.Generic;
using System.Text;
using OrbitalMechanics;
using OrbitalMechanics.Solver;

namespace OrbitalMechanicsTests
{
    public class PlanetOrbits
    {

        static public Orbit CreateMercuryOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 0.387,
                Eccentricity = 0.206,
            };
        }
        static public Orbit CreateVenusOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 0.723,
                Eccentricity = 0.007,
            };
        }
        static public Orbit CreateEarthOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 149598023.0 * Numbers.KMToM,
                Eccentricity = 0.0167086,
            };
        }
        static public Orbit CreateMoonOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 384399 * Numbers.KMToM,
                Eccentricity = 0.0549,
            };
        }
        static public Orbit CreateMarsOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 1.524,
                Eccentricity = 0.093,
            };
        }
        static public Orbit CreateJupiterOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 5.2044,
                Eccentricity = 0.049,
            };
        }
        static public Orbit CreateSaturnOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 9.58260,
                Eccentricity = 0.057,
            };
        }
        static public Orbit CreateUranusOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 19.2184,
                Eccentricity = 0.046,
            };
        }
        static public Orbit CreateNeptuneOrbit()
        {
            return new Orbit()
            {
                SemiMajorAxis_m = 30.11,
                Eccentricity = 0.010,
            };
        }
    }
}
