using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProgram
{
    public class Line : Function
    {
        public double B { get; set; } = 0.0;           // публичное свойство B

        public Line() : base() { }

        public Line(double a, double b) : base(a)
        {
            B = b;
        }

        public Line(Line other) : base(other)
        {
            B = other.B;
        }

        public override double Calculate(double x)
        {
            return A * x + B;                          // y = Ax + B
        }

        public override string ToString()
        {
            return $"Line: y = {A}x + {B}";
        }
    }
}