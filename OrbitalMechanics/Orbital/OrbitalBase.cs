using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics.Orbital
{
    class OrbitalBase
    {
        public OrbitalBase parent;                                          // The object that this object orbits around
        public List<OrbitalBase> satellites = new List<OrbitalBase>();      // List of satellites orbiting around this object

        public double MassKG;                                               // KiloGrams

        public double Eccentricity;                                         // Unitless
        public double SemiMajorAxisKM;                                      // KiloMeters
        public double InclinationDeg;                                       // Degrees
        public double LongitudeOfANDeg;                                     // Longitude of Ascending Node in degrees
        public double ArgumentOfPeriapsisDeg;                               // Degrees
        public double TimeOfPeriapsis;                                      // Seconds 


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



        public double CalculatePeriapsisKM()
        {
            return SemiMajorAxisKM * (1 - Eccentricity);
        }
        public double CalculateApoapsisKM()
        {
            return SemiMajorAxisKM * (1 + Eccentricity);
        }


        // Force that this object would exert on another at given distance. (m / s^2)
        public double CalculateGravityFromDistance(double distanceM)
        {
            return Numbers.G * (MassKG / (distanceM * distanceM));
        }
        // Orbital period in seconds of the time it takes for this
        // object to complete one orbit around it's parent.
        public double CalculateOrbitalPeriodSec()
        {
            if (parent != null)
            {
                double SemiMajorAxisM = SemiMajorAxisKM * Numbers.KMToM;
                double SMA3 = SemiMajorAxisM * SemiMajorAxisM * SemiMajorAxisM;

                double top = (4 * Numbers.PISquared * SMA3);
                double bottom = (Numbers.G * parent.MassKG);

                double period = System.Math.Sqrt(top / bottom);

                return period;
            }
            return 0;
        }
        // TODO: Implement method
        public double CalculateMeanAnomalyDeg(double atTimeSec)
        {
            return 0;
        }
    }
}
