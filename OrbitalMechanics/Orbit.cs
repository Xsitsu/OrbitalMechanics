using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics
{
    public class Orbit
    {
        public double SemiMajorAxis_m                                   // Meters
        {
            get { return ellipse_m.SemiMajorAxis_l; }
            set
            {
                ellipse_m.SemiMajorAxis_l = value;
                CalculateApsides();
            }
        }
        public double Eccentricity                                      // Unitless
        {
            get { return ellipse_m.Eccentricity; }
            set
            {
                ellipse_m.Eccentricity = value;
                CalculateApsides();
            }
        }
        public double Inclination_deg;                                  // Degrees
        public double LongitudeOfAN_deg;                                // Longitude of Ascending Node in degrees
        public double ArgumentOfPeriapsis_deg;                          // Degrees
        public double PeriapsisEpoch_sec;                               // Seconds 
        public double Periapsis_m                                       // Meters
        {
            get { return periapsis_m; }
        }
        public double Apoapsis_m                                        // Meters
        {
            get { return apoapsis_m; }
        }
        public double SemiMinorAxis_m                                   // Meters
        {
            get { return ellipse_m.SemiMinorAxis_l ; }
        }

        public void SetOrbitData(double semiMajorAxis_m, double eccentricity, double inclination_deg,
        double longitudeOfAN_deg, double argumentOfPeriapsis_deg, double periapsisEpoch_sec)
        {
            this.ellipse_m.SemiMajorAxis_l = semiMajorAxis_m;
            this.ellipse_m.Eccentricity = eccentricity;
            this.Inclination_deg = inclination_deg;
            this.LongitudeOfAN_deg = longitudeOfAN_deg;
            this.ArgumentOfPeriapsis_deg = argumentOfPeriapsis_deg;
            this.PeriapsisEpoch_sec = periapsisEpoch_sec;

            CalculateApsides();
        }

        private void CalculateApsides()
        {
            periapsis_m = ellipse_m.SemiMajorAxis_l - ellipse_m.FocalDistance_l;
            apoapsis_m = ellipse_m.SemiMajorAxis_l + ellipse_m.FocalDistance_l;
        }


        private Ellipse ellipse_m = new Ellipse();                      // Meters (for length members)
        //private double inclination_deg;                               // Degrees
        //private double longitudeOfAN_deg;                             // Longitude of Ascending Node in degrees
        //private double argumentOfPeriapsis_deg;                       // Degrees
        //private double periapsisEpoch_sec;                            // Seconds
        private double periapsis_m;                                     // Meters
        private double apoapsis_m;                                      // Meters

    }
}
