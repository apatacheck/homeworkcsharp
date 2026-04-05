//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 
namespace FigureTask
{
    public class Circle : Figure
    {
        private double radius;
        public Circle(double radius)
        {
            if (radius <= 0 )
                throw new ArgumentException("Радиус круга должны быть больше 0");
            this.radius = radius;
        }
        public override double GetArea() {
            return Math.PI* radius *radius;
        }
        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }
        public override void Print()
        {
            Console.WriteLine($"Круг: радиус={radius}, площадь={GetArea():F2}, " + $"периметр={GetPerimeter():F2}");
        }
    }
}