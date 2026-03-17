using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics
{
    public class Orbit
    {
        public double SemiMajorAxis_m                                   // Meters
        {
            get { return semiMajorAxis_m; }
            set
            {
                semiMajorAxis_m = value;
                CalculateDerivedValues();
            }
        }
        public double Eccentricity                                      // Unitless
        {
            get { return eccentricity; }
            set
            {
                eccentricity = value;
                CalculateDerivedValues();
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
            get { return semiMinorAxis_m; }
        }
        public double FocalDistance_m                                   // Meters
        {
            get { return focalDistance_m; }
        }

        public void SetOrbitData(double semiMajorAxis_m, double eccentricity, double inclination_deg,
        double longitudeOfAN_deg, double argumentOfPeriapsis_deg, double periapsisEpoch_sec)
        {
            this.semiMajorAxis_m = semiMajorAxis_m;
            this.eccentricity = eccentricity;
            this.Inclination_deg = inclination_deg;
            this.LongitudeOfAN_deg = longitudeOfAN_deg;
            this.ArgumentOfPeriapsis_deg = argumentOfPeriapsis_deg;
            this.PeriapsisEpoch_sec = periapsisEpoch_sec;

            CalculateDerivedValues();
        }

        private void CalculateDerivedValues()
        {
            semiMinorAxis_m = semiMajorAxis_m * Math.Sqrt(1 - Math.Pow(eccentricity, 2));
            focalDistance_m = Math.Sqrt(Math.Pow(semiMajorAxis_m, 2) - Math.Pow(semiMinorAxis_m, 2));
            periapsis_m = semiMajorAxis_m - focalDistance_m;
            apoapsis_m = semiMajorAxis_m + focalDistance_m;
        }

        private double semiMajorAxis_m;                                 // Meters
        private double semiMinorAxis_m;                                 // Meters
        private double focalDistance_m;                                 // Meters
        private double eccentricity;                                    // Unitless
        private double periapsis_m;                                     // Meters
        private double apoapsis_m;                                      // Meters

        public override string ToString()
        {
            string str = "{";
            str += "SemiMajorAxis: " + SemiMajorAxis_m;
            str += ", Eccentricity: " + Eccentricity;
            str += ", Inclination: " + Inclination_deg;
            str += ", LongitudeOfAN: " + LongitudeOfAN_deg;
            str += ", ArgumentOfPeriapsis: " + ArgumentOfPeriapsis_deg;
            str += ", PeriapsisEpoch: " + PeriapsisEpoch_sec;
            str += "}";
            return str;
        }
    }
}
