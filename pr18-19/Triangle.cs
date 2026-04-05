namespace FigureTask
{
    [Serializable]
    public class Triangle : Figure
    {
        public double A;
        public double B;
        public double C;

        //конструктор по умолчанию
        public Triangle()
        {
            A = 3;
            B = 4;
            C = 5;
        }

        //конструктор с параметрами
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                throw new ArgumentException("Некорректный треугольник");
            }
            A = a;
            B = b;
            C = c;
        }

        //конструктор копирования
        public Triangle(Triangle other)
        {
            A = other.A;
            B = other.B;
            C = other.C;
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
