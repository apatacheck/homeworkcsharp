namespace FigureTask
{
    [Serializable]
    public class Circle : Figure
    {
        private double radius;
        public Circle(double radius) => this.radius = radius;

        public override double GetArea() => Math.PI * radius * radius;
        public override double GetPerimeter() => 2 * Math.PI * radius;

        public override string ToString()
        {
            Console.WriteLine($"Круг: радиус={radius}, площадь={GetArea():F2}, " + $"периметр={GetPerimeter():F2}");
        }
    }
}
