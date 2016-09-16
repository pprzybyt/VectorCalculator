using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCalculator
{
    public class Pair
    {
        public double Force { get; set; }
        public double Angle { get; set; }   // in radians
        public double XForce { get; set; }
        public double YForce { get; set; }
        public enum Option {Angle, NoAngle}


        public Pair( double a, double b, Option o)
        {
            if (o == Option.Angle)
            {
                this.Force = a;
                this.Angle = Math.PI / 180 * b;
                CalculateXYForces();
            }
            else if(o == Option.NoAngle)
            {
                this.XForce = a;
                this.YForce = b;
                this.Force = Math.Sqrt(a * a + b * b);
                CalculateAngle();
            }
        }


        private void CalculateAngle()
        {
            this.Angle = Math.Atan2(this.YForce,this.XForce);
        }


        private void CalculateXYForces()
        {
            this.XForce = this.Force * Math.Cos(this.Angle);
            this.YForce = this.Force * Math.Sin(this.Angle);
        }

        public override string ToString()
        {
            double angleInGrades = this.Angle * 180 / Math.PI;
            if (angleInGrades < 0)
                angleInGrades += 360;
      
            return "Force: " + Math.Round(this.Force,2).ToString()+ "N" +
                   "    Angle: " + Math.Round(angleInGrades,2).ToString() + "°";
        }




    }
}
