
namespace FigureTask
{
    [Serializable]
    public class Rectangle : Figure
    {
        public double width { get; set; }
        public double height { get; set; }

        //конструктор по умолчанию
        public Rectangle()
        {
            width = 1;
            height = 1;
        }

        //конструктор с параметрами 
        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentException("Некорректный прямоугольник");
            }
            this.width = width;
            this.height = height;
        }

        public override double GetArea() => width * height;
        public override double GetPerimeter() => 2 * (width + height);

        public override void Print()
        {
            return $"Прямоугольник: ширина={width:F2}, высота={height:F2}, " + $"площадь={GetArea():F2}, периметр={GetPerimeter():F2}";
        }
    }
}