using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns
{
    class RoundHole
    {
        public int Radius { get; set; }

        public bool Fits(RoundPeg roundPeg)
        {
            return Radius >= roundPeg.Radius;
        }
    }
    class RoundPeg
    {
        public int Radius { get; set; }
    }
    class SquarePeg
    {
        public int Side { get; set; }
    }
    class SquarePegAdapter : RoundPeg
    {
        SquarePeg peg;
        new public int Radius { get {
                return (int)(peg.Side * Math.Sqrt(2) / 2);
            } }

        public SquarePegAdapter(SquarePeg squarePeg)
        {
            this.peg = squarePeg;
        }

    }
}
