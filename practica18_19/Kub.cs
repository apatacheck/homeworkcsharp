using System;

namespace MyProgram
{
    public class Kub : Function
    {
        public double B { get; set; } = 0.0;
        public double C { get; set; } = 0.0;

        public Kub() : base() { }

        public Kub(double a, double b, double c) : base(a)
        {
            B = b;
            C = c;
        }

        public Kub(Kub other) : base(other)
        {
            B = other.B;
            C = other.C;
        }

        public override double Calculate(double x)
        {
            return A * x * x + B * x + C;              // y = Ax² + Bx + C
        }

        public override string ToString()
        {
            return $"Kub: y = {A}x^2 + {B}x + {C}";
        }
    }
}