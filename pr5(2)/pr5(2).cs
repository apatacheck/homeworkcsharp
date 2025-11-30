using System;


class Program
{
    static int FuncCount(int n)
    {
        n = Math.Abs(n);

        if (n < 2)
            return 0;

        int count = 0;
        int d = 2;

        while (d * d <= n)
        {
            if (n % d == 0)
            {
                count++;
                while (n % d == 0)
                {
                    n /= d;
                }
            }
            d++;
        }

        if (n > 1)
        {
            count++;
        }

        return count;
    }

    // а) для каждого целого числа на отрезке [a, b] вывести на экран количество его простых множителей;
    static void PrimeFactorsCount(int a, int b)
    {
        Console.WriteLine("\n а) Количество простых множителей: ");
        for (int i = a; i <= b; i++)
        {
            int count = FuncCount(i);
            Console.WriteLine($"{i} : {count}");
        }
    }

    // б) на отрезке [a, b] найти все числа, имеющие наибольшее количество простых множителей;
    static void MaxPrimeFactors(int a, int b)
    {
        Console.WriteLine("\n б) Числа с наибольшим количеством простых множителей:");
        int maxCount = 0;
        List<int> maxNumbers = new List<int>();

        for (int i = a; i <= b; i++)
        {
            int count = FuncCount(i);
            if (count > maxCount)
            {
                maxCount = count;
                maxNumbers.Clear();
                maxNumbers.Add(i);
            }
            else if (count == maxCount)
            {
                maxNumbers.Add(i);
            }
        }

        Console.WriteLine($"Максимум простых множителей: {maxCount}");
        Console.WriteLine("У чисел: " + string.Join(", ", maxNumbers));
    }

    // c) на отрезке [a, b] найти все числа, количество простых множителей которого равно числу С
    static void FindNumbers(int a, int b)
    {
        Console.Write("\n Введите число C: ");
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine($" с) Числа, у которых количество простых множителей равно {c}:");
        bool flag = false;

        for (int i = a; i <= b; i++)
        {
            if (FuncCount(i) == c)
            {
                Console.WriteLine(i);
                flag = true;
            }
        }

        if (!flag)
        {
            Console.WriteLine("Таких чисел нет в заданном диапазоне.");
        }
    }

    // д) для заданного числа А вывести на экран ближайшее следующее за ним число, количество простых множителей которого равна количеству простых множителей числа А.
    static void FindNearNumber()
    {
        Console.Write("\nВведите число A: ");
        int A = int.Parse(Console.ReadLine());

        int counta = FuncCount(A);
        int next = A + 1;

        while (true)
        {
            if (FuncCount(next) == counta)
            {
                Console.WriteLine($" д) Ближайшее число после {A} с {counta} простыми множителями: {next}");
                break;
            }
            next++;
        }
    }

    static void Main()
    {
        Console.Write("Введите начало диапазона: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите конец диапазона: ");
        int b = int.Parse(Console.ReadLine());

        PrimeFactorsCount(a, b);
        MaxPrimeFactors(a, b);
        FindNumbers(a, b);
        FindNearNumber();
    }
}
