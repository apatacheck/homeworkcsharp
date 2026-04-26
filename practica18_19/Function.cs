using System;
using System.Text.Json.Serialization;

namespace MyProgram
{
    [JsonPolymorphic]
    [JsonDerivedType(typeof(Line), "Line")]
    [JsonDerivedType(typeof(Kub), "Kub")]
    [JsonDerivedType(typeof(Hyperbola), "Hyperbola")]
    public abstract class Function : IComparable<Function>
    {
        public double A { get; set; } = 0.0;           // публичное свойство A

        public Function() { }                          // пустой конструктор

        public Function(double a)
        {
            A = a;
        }

        public Function(Function other)
        {
            A = other.A;
        }

        public abstract double Calculate(double x);

        public int CompareTo(Function other)
        {
            if (other == null) return 1;
            return A.CompareTo(other.A);
        }

        public override string ToString()
        {
            return $"Function A={A}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Function f) return A == f.A;
            return false;
        }

        public override int GetHashCode()
        {
            return A.GetHashCode();
        }
    }
}