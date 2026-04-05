namespace FigureTask
{
    [Serializable]
    public class Circle : Figure
    {
        public double radius;

        //конструктор по умолчанию
        public Circle()
        {
            radius = 1;
        }

        //конструктор с параметрами
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentException("Некорректный круг");
            }
            this.radius = radius;
        }

        //конструктор копирования
        public Circle(Circle other)
        {
            radius = other.radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return $"Круг: радиус={radius:F2}, площадь={GetArea():F2}, " + $"периметр={GetPerimeter():F2}";
        }
    }
}
