using System;
//14. Для каждой строки найти сумму элементов с номерами от k1 до k2 и записать данные в новый массив
class Program
{
    static void Main()
    {
        Random rnd = new Random();

        Console.Write("Введите размер матрицы n: ");
        int n = Math.Abs(int.Parse(Console.ReadLine()!));
        //создание матрицы с рандомными значениями элементов 
        int[,] matrix = new int[n, n];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = rnd.Next(1, 10);
            }
        }
        //вывод матрицы
        Console.WriteLine("\nМатрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }


        Console.Write("\nВведите начальный индекс k1: ");
        int k1 = int.Parse(Console.ReadLine()!);
        Console.Write("Введите конечный индекс k2: ");
        int k2 = int.Parse(Console.ReadLine()!);
        //проверка k
        while (k1 < 0 || k2 >= n || k1 > k2)
        {
            Console.WriteLine("Некорректные значения k1 и/или k2.\n");
            Console.Write("\nВведите начальный индекс k1: ");
            k1 = int.Parse(Console.ReadLine()!);
            Console.Write("Введите конечный индекс k2: ");
            k2 = int.Parse(Console.ReadLine()!);
        }
        //создание массива сумм
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            for (int j = k1; j <= k2; j++)
            {
                result[i] += matrix[i, j];
            }
        }

        Console.WriteLine("\nМассив сумм:");
        foreach (int sum in result)
        {
            Console.Write(sum + " ");
        }
    }
}
