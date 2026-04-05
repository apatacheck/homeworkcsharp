//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 

namespace FigureTask
{
    public class Triangle : Figure
    {
        private double a, b, c;
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
                throw new ArgumentException("Стороны треугольника должны быть больше 0");
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override double GetArea()
        {
            double p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        public override double GetPerimeter() 
        { 
            return (a + b + c);
        }
        public override void Print()
        {
            Console.WriteLine($"Треугольник: стороны ({a}, {b}, {c}), " + $"площадь={GetArea():F2}, периметр={GetPerimeter():F2}");
        }
    }
}