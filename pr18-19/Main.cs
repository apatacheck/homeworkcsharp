//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 

namespace FigureTask
{
    class Program
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("figures.txt");
            List<Figure> figures = new List<Figure>();
            foreach (string line in lines)
                {
                    if (line.Trim() == "") continue;
                    string[] parts = line.Split(' ');
                    string type = parts[0].ToLower();

                    if (type == "rectangle")
                        figures.Add(new Rectangle(double.Parse(parts[1]), double.Parse(parts[2])));
                    else if (type == "circle")
                        figures.Add(new Circle(double.Parse(parts[1])));
                    else if (type == "triangle")
                        figures.Add(new Triangle(double.Parse(parts[1]), double.Parse(parts[2]), double.Parse(parts[3])));
                }


            Console.WriteLine("Исходный массив:");
            foreach (var fig in figures)
            {
                fig.Print();
            }

            figures.Sort();
            Console.WriteLine("\nПосле сортировки:");
            foreach (var fig in figures)
            {
                fig.Print();
            }
        }
    }
}