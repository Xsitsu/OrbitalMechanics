using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics
{
    public class Orbit
    {
        private double eccentricity;                                    // Unitless
        private double semiMajorAxis_m;                                 // Meters
        //private double inclination_deg;                                 // Degrees
        //private double longitudeOfAN_deg;                               // Longitude of Ascending Node in degrees
        //private double argumentOfPeriapsis_deg;                         // Degrees
        //private double periapsisEpoch_sec;                              // Seconds 

        private double periapsis_m;                                     // Meters
        private double apoapsis_m;                                      // Meters

        public double Eccentricity                                      // Unitless
        {
            get { return eccentricity; }
            set
            {
                eccentricity = value;
                CalculateApsides();
            }
        }
        public double SemiMajorAxis_m                                   // Meters
        {
            get { return semiMajorAxis_m; }
            set
            {
                semiMajorAxis_m = value;
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

        public void SetOrbitData(double eccentricity, double semiMajorAxis_m, double inclination_deg,
        double longitudeOfAN_deg, double argumentOfPeriapsis_deg, double periapsisEpoch_sec)
        {
            this.eccentricity = eccentricity;
            this.semiMajorAxis_m = semiMajorAxis_m;
            this.Inclination_deg = inclination_deg;
            this.LongitudeOfAN_deg = longitudeOfAN_deg;
            this.ArgumentOfPeriapsis_deg = argumentOfPeriapsis_deg;
            this.PeriapsisEpoch_sec = periapsisEpoch_sec;

            CalculateApsides();
        }

        private void CalculateApsides()
        {
            periapsis_m = semiMajorAxis_m * (1 - eccentricity);
            apoapsis_m = semiMajorAxis_m * (1 + eccentricity);
        }

    }
}
