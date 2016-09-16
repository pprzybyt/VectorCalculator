using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorCalculator
{
    public class ResultVector : Pair
    {
        public ResultVector( Pair a, Pair b)
            : base (a.XForce+b.XForce, a.YForce+b.YForce,Option.NoAngle)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

    }
}
