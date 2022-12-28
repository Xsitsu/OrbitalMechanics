using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics
{
    class Orbit
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
            get { return eccentricity; }
            set
            {
                eccentricity = value;
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

        private void CalculateApsides()
        {
            periapsis_m = semiMajorAxis_m * (1 - eccentricity);
            apoapsis_m = semiMajorAxis_m * (1 + eccentricity);
        }

    }
}
