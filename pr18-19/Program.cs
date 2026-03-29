//Задание 1
//1. Создать абстрактный класс Figure с методами вычисления площади и периметра, а также
//методом, выводящим информацию о фигуре на экран.
//2. Создать производные классы: Rectangle(прямоугольник), Circle(круг), Triangle
//(треугольник) со своими методами вычисления площади и периметра.
//3. Создать массив n фигур и вывести полную информацию о фигурах на экран. 
using System;
using System.IO;
//13. сумму значений узлов в дереве, имеющих только одно правое поддерево;
namespace FigureTask
{
    abstract class Figure
    {
        abstract public void Show();
        abstract public float Area();
        abstract public float Perimeter();
    }
}