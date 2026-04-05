
namespace FigureTask
{
    [Serializable]
    public class Circle : Figure
    {
        public double Radius { get; set; }

        //конструктор по умолчанию
        public Circle()
        {
            Radius = 1;
        }

        //конструктор с параметрами
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Некорректный круг");
            }
            Radius = radius;
        }

        //конструктор копирования
        public Circle(Circle other)
        {
            Radius = other.Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override string ToString()
        {
            return $"Круг: радиус={Radius:F2}, площадь={GetArea():F2}, " +  $"периметр={GetPerimeter():F2}";
        }
    }
}