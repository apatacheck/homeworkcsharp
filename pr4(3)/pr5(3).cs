using System;

public class pr5_3
{
    public static int Ackerman(int n, int m)
    {
        if (n == 0)
        {
            return m + 1;
        }
        else if (m == 0)
        {
            return Ackerman(n - 1, 1);
        }
        else
        {
            return Ackerman(n - 1, Ackerman(n, m - 1));
        }
    }

    public static void Main(string[] args)
    {
        Console.Write("Введите неотрицательное целое число n: ");
        int n = int.Parse(Console.ReadLine()!);

        Console.Write("Введите неотрицательное целое число m: ");
        int m = int.Parse(Console.ReadLine()!);

        int answer = Ackerman(n, m);
        Console.WriteLine($"A({n}, {m}) = {answer}");
    }
}
