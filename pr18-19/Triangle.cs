namespace FigureTask
{
    [Serializable]
    public class Triangle : Figure
    {
        private double a, b, c;
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }


        public override double GetArea()
        {
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }

        public override string ToString()
        {
            return $"Треугольник: стороны ({A:F2}, {B:F2}, {C:F2}), " + $"площадь={GetArea():F2}, периметр={GetPerimeter():F2}";
        }
    }
}
