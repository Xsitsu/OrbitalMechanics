using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics.Solver
{
    public abstract class ISolver
    {
        public double CalculateOrbitalPeriod_sec(double centerMass_kg, Orbit orbit)
        {
            double SMA3 = orbit.SemiMajorAxis_m * orbit.SemiMajorAxis_m * orbit.SemiMajorAxis_m;

            double top = (4 * Numbers.PISquared * SMA3);
            double bottom = (Numbers.G * centerMass_kg);

            double period = System.Math.Sqrt(top / bottom);

            return period;
        }
        public virtual double GetOrbitDistance_m(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            Offset offset = CalculateOffset_m(centerMass_kg, orbit, atTime_sec);
            double x = offset.X;
            double y = offset.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public abstract double GetOrbitAngle_deg(double centerMass_kg, Orbit orbit, double atTime_sec);
        public abstract Offset CalculateOffset_m(double centerMass_kg, Orbit orbit, double atTime_sec);

        protected double CalculateMeanAnomaly(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            double period_sec = CalculateOrbitalPeriod_sec(centerMass_kg, orbit);
            double elapsedTime_sec = atTime_sec - orbit.PeriapsisEpoch_sec;
            double percent = elapsedTime_sec / period_sec;
            double angle_deg = percent * 360;
            return angle_deg;
        }
        protected double CalculateEccentricAnomaly(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            double meanAnomaly_deg = CalculateMeanAnomaly(centerMass_kg, orbit, atTime_sec);

            double eccentricAnomaly_deg = meanAnomaly_deg;
            double tolerance = System.Math.Pow(1, -8);

            int maxIterations = 12;
            int iterationCount = 0;
            while (iterationCount < maxIterations)
            {
                iterationCount++;
                double delta = (eccentricAnomaly_deg - orbit.Eccentricity * Math.Sin(eccentricAnomaly_deg) - meanAnomaly_deg) / (1 - orbit.Eccentricity * Math.Cos(eccentricAnomaly_deg));
                eccentricAnomaly_deg -= delta;
                if (System.Math.Abs(delta) < tolerance)
                {
                    break;
                }
            }

            return eccentricAnomaly_deg;
        }
        protected double CalculateTrueAnomaly(double centerMass_kg, Orbit orbit, double atTime_sec)
        {
            double eccentricAnomaly_deg = CalculateEccentricAnomaly(centerMass_kg, orbit, atTime_sec);
            double eccentricity = orbit.Eccentricity;

            double cosTrueAnomaly = (Math.Cos(eccentricAnomaly_deg) - eccentricity) / (1 - eccentricity * Math.Cos(eccentricAnomaly_deg));
            double sinTrueAnomaly = Math.Sqrt(1 - eccentricity * eccentricity) * Math.Sin(eccentricAnomaly_deg) / (1 - eccentricity * Math.Cos(eccentricAnomaly_deg));
            double trueAnomaly = Math.Atan2(sinTrueAnomaly, cosTrueAnomaly);

            return trueAnomaly;
        }
    }
}
