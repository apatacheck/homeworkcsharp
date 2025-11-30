using System;
using System.IO;
using System.Collections.Generic;
// Найти такую точку (в плоскости), сумма расстояний от которой до остальных точек множества максимальна.
    struct SPoint
    {
        public int x, y;

        public SPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Show()
        {
            Console.WriteLine("({0}, {1})", x, y);
        }

        // расстояние между двумя точками
        public double DistanceTo(SPoint other)
        {
            return Math.Sqrt((x - other.x) * (x - other.x) + (y - other.y) * (y - other.y));
        }
    }

    class Program
    {
        static public SPoint[] Input() //задание массива точек
        {
            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine()!);
                SPoint[] ar = new SPoint[n];

                for (int i = 0; i < n; i++)
                {
                    string[] text = fileIn.ReadLine()!.Split(' ');
                    ar[i] = new SPoint(int.Parse(text[0]), int.Parse(text[1]));
                   
                }

                return ar;
            }
        }

        static void Print(SPoint[] array) //вывод 
        {
            foreach (SPoint item in array)
                item.Show();
        }

        static List<int> FindMaxSumPoints(SPoint[] pts, out double maxSum) //основная функция
        {
            int n = pts.Length;
            double[] sums = new double[n];
            maxSum = -1;

            for (int i = 0; i < n; i++)
            {
                sums[i] = 0;

                for (int j = 0; j < n; j++)
                {
                    if (i != j)
                    sums[i] += pts[i].DistanceTo(pts[j]);
                }

                if (sums[i] > maxSum)
                maxSum = sums[i];
            }

            List<int> result = new List<int>();

            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(sums[i] - maxSum) < 1e-9) //погрешность double
                result.Add(i);
            }

            return result;
        }

        static void Main()
        {
            SPoint[] array = Input();

            Console.WriteLine("Точки:");
            Print(array);

            List<int> indices = FindMaxSumPoints(array, out double maxSum);
            Console.WriteLine("\nТочки с максимальной суммой расстояний:");
            foreach (int idx in indices)
                array[idx].Show();

            Console.WriteLine($"\nМаксимальная сумма расстояний: {maxSum}");
        }
    }

