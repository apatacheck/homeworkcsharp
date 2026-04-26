using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProgram
{
    public class Hyperbola : Function
    {
        public double B { get; set; } = 0.0;

        public Hyperbola() : base() { }

        public Hyperbola(double a, double b) : base(a)
        {
            B = b;
        }

        public Hyperbola(Hyperbola other) : base(other)
        {
            B = other.B;
        }

        public override double Calculate(double x)
        {
            if (Math.Abs(x) < 0.000001) return 0;
            return A / x + B;                          // y = A/x + B
        }

        public override string ToString()
        {
            return $"Hyperbola: y = {A}/x + {B}";
        }
    }
}