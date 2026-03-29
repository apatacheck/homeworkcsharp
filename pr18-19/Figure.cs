//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 

namespace FigureTask
{
    public abstract class Figure : IComparable
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract void  Print();

        public int CompareTo(object obj)
        {
            Figure other = (Figure)obj;   // приведение
            if (this.GetArea() == other.GetArea())
                return 0;
            else if (this.GetArea() > other.GetArea())
                return 1;
            else
                return -1;
        }
    }
}