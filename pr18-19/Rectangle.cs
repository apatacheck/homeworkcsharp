//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 

namespace FigureTask
{
    public class Rectangle : Figure
    {
        private double width, height;
        public Rectangle(double width, double height)
        {
            if (width <= 0 || height <= 0)
                throw new ArgumentException("Стороны прямоугольника должны быть больше 0");
            this.width = width;
            this.height = height;
        }

        public override double GetArea()
        {
            return width* height;
        }
        public override double GetPerimeter()
        {
            return 2 * (width + height);
        }
        public override void Print()
        {
            Console.WriteLine($"Прямоугольник: ширина={width}, высота={height}, " + $"площадь={GetArea():F2}, периметр={GetPerimeter():F2}");
        }
    }
}