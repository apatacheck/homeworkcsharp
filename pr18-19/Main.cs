using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FigureTask
{
    class Program
    {
        static void Print(List<Figure> objects)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список объектов пуст.");
            }
            else
            {
                Console.WriteLine("Список объектов:");
                foreach (Figure item in objects)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            List<Figure> objects = new List<Figure>();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream f = new FileStream("figures.dat", FileMode.OpenOrCreate))
            {
                if (f.Length != 0)
                {
                    objects = (List<Figure>)formatter.Deserialize(f);
                    Console.WriteLine("Фигуры загружены из файла:");
                    Print(objects);
                }
                else
                {
                    Console.WriteLine("Файл пуст. Создаем новые фигуры...");
                    objects.Add(new Rectangle(5, 3));
                    objects.Add(new Circle(4));
                    objects.Add(new Triangle(3, 4, 5));
                    objects.Add(new Rectangle(2, 6));
                    objects.Add(new Circle(2.5));
                    objects.Add(new Triangle());
                    Print(objects);
                }
            }


            objects.Sort();
            Console.WriteLine("Фигуры отсортированы");
            //Print(objects);

            using (FileStream f = new FileStream("figures.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, objects);
            }
        }
    }
}