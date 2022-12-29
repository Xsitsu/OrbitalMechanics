using System;
using System.Collections.Generic;
using System.Text;

namespace OrbitalMechanics
{
    public class Ellipse
    {
        public Ellipse() { }
        public Ellipse(double semiMajorAxis_l, double eccentricity)
        {
            this.semiMajorAxis_l = semiMajorAxis_l;
            this.eccentricity = eccentricity;
            CalculateSemiMinorAxis();
            CalculateFocalDistance();
        }
        public double SemiMajorAxis_l
        {
            get { return semiMajorAxis_l; }
            set
            {
                semiMajorAxis_l = value;
                CalculateSemiMinorAxis();
                CalculateFocalDistance();
            }
        }
        public double SemiMinorAxis_l
        {
            get { return semiMinorAxis_l; }
        }
        public double Eccentricity
        {
            get { return eccentricity; }
            set
            {
                eccentricity = value;
                CalculateSemiMinorAxis();
                CalculateFocalDistance();
            }
        }
        public double FocalDistance_l
        {
            get { return focalDistance_l; }
        }


        private void CalculateSemiMinorAxis()
        {
            semiMinorAxis_l = semiMajorAxis_l * Math.Sqrt(1 - Math.Pow(eccentricity, 2));
        }
        private void CalculateFocalDistance()
        {
            focalDistance_l = Math.Sqrt(Math.Pow(semiMajorAxis_l, 2) - Math.Pow(semiMinorAxis_l, 2));
        }

        private double semiMajorAxis_l;                                     // Length
        private double semiMinorAxis_l;                                     // Length
        private double eccentricity;                                        // Unitless
        private double focalDistance_l;                                     // Length
    }
}
