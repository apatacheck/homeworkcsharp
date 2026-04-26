//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 

namespace FigureTask
{
    [Serializable]
    public abstract class Figure : IComparable<Figure>
    {

        public abstract double GetArea();
        public abstract double GetPerimeter();
        public abstract override string ToString();

        public int CompareTo(Figure other)
        {
            if (other == null) return 1;
            return this.GetArea().CompareTo(other.GetArea()); //сравниваем по площади 
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Figure other = (Figure)obj;
            return this.GetArea() == other.GetArea() &&
                   this.GetPerimeter() == other.GetPerimeter();
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(GetArea(), GetPerimeter());
        }
    }
}
