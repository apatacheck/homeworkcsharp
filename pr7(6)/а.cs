using System;

class Program
{
    static int[][] Input(out int n)
    {
        Console.WriteLine("Введите размерность массива n: ");
        n = int.Parse(Console.ReadLine()!);

        int[][] Arr = new int[n][];

        for (int j = 0; j < n; j++)
        {
            Arr[j] = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("a[{0}][{1}]= ", i, j);
                Arr[j][i] = int.Parse(Console.ReadLine()!);
            }
        }
        return Arr;
    }

    static void Print(int[][] Arr, int n, int m) //вывод массива
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0,5} ", Arr[j][i]);
            }
            Console.WriteLine();
        }
    }

    static void ShiftColumn(int[][] Arr, ref int m, int k) //сдвиг  столбцов
    {
        for (int j = m; j > k; j--)
        {
            Arr[j] = Arr[j - 1];
        }
    }

    static void AddColumn(ref int[][] Arr, ref int n, ref int m, int k) //добавления столбца
    {
        Array.Resize(ref Arr, m + 1);
        ShiftColumn(Arr, ref m, k);
        Arr[k] = new int[n];

        Console.WriteLine("Введите элементы нового столбца:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("a[{0}][{1}]=", i, k);
            Arr[k][i] = int.Parse(Console.ReadLine()!);
        }

        m++;
    }

    static void AddColumnBeforeNumber(ref int[][] Arr, ref int n, ref int m, int targetNumber)
    {
        bool[] FlagColumns = new bool[m];
        int insertCount = 0;

        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n; i++)
            {
                if (Arr[j][i] == targetNumber)
                {
                    FlagColumns[j] = true;
                    insertCount++;
                    break;
                }
            }
        }

        if (insertCount == 0)
        {
            Console.WriteLine("Число {0} не найдено в массиве.", targetNumber);
            return;
        }

        for (int j = m - 1; j >= 0; j--)
        {
            if (FlagColumns[j])
            {
                AddColumn(ref Arr, ref n, ref m, j);
            }
        }
    }

    static void Main()
    {
        int n, m;
        int[][] Arr = Input(out n);
        m = n;

        Console.WriteLine("Исходный массив:");
        Print(Arr, n, m);

        Console.WriteLine("Введите число для поиска:");
        int targetNumber = int.Parse(Console.ReadLine()!);

        AddColumnBeforeNumber(ref Arr, ref n, ref m, targetNumber);

        Console.WriteLine("Измененный массив:");
        Print(Arr, n, m);
    }
}
