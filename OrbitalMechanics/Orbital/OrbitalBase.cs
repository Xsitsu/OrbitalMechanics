using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics.Orbital
{
    class OrbitalBase
    {
        public OrbitalBase parent;                                          // The object that this object orbits around
        public List<OrbitalBase> satellites = new List<OrbitalBase>();      // List of satellites orbiting around this object

        public double MassKg;                                               // KiloGrams
        public double OrbitRadiusM;                                         // Meters
        public double OrbitInclinationDeg;                                  // Degrees relative to parent's equator
        public double LongitudeOfANDeg;                                     // Longitude of Ascending Node in degrees
        public double AxialTiltDeg;                                         // Degrees relative to orbital plane
        public double RotationalPeriodSec;                                  // Seconds sidereal

        public void AddSatellite(OrbitalBase satellite)
        {
            if (!HasSatellite(satellite))
            {
                satellites.Add(satellite);
                satellite.AddTo(this);
            }
        }
        public void RemoveSatellite(OrbitalBase satellite)
        {
            if (HasSatellite(satellite))
            {
                satellite.RemoveFrom(this);
                satellites.Remove(satellite);
            }
        }
        public bool HasSatellite(OrbitalBase satellite)
        {
            foreach (OrbitalBase sat in satellites)
            {
                if (sat == satellite) return true;
            }
            return false;
        }
        public void AddTo(OrbitalBase parent)
        {
            this.parent = parent;
        }
        public void RemoveFrom(OrbitalBase parent)
        {
            if (this.parent == parent)
            {
                this.parent = null;
            }
        }




        // Orbital period in seconds of the time it takes for this
        // object to complete one orbit around it's parent.
        public double CalculateOrbitalPeriod()
        {
            if (parent != null)
            {
                double rad3 = OrbitRadiusM * OrbitRadiusM * OrbitRadiusM;

                double top = (4 * Numbers.PISquared * rad3);
                double bottom = (Numbers.G * parent.MassKg);

                double period = System.Math.Sqrt(top / bottom);

                return period;
            }
            return 0;
        }
        // Force that this object would exert on another at given distance. (m / s^2)
        public double CalculateGravityFromDistance(double distanceM)
        {
            return Numbers.G * (MassKg / (distanceM * distanceM));
        }
    }
}
