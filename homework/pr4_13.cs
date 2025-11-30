using System;
class Practice4_13
{
    static void Main()
    {
        Console.Write("Задайте точность вычислений е: ");
        double e = double.Parse(Console.ReadLine()!);
        double a = 3, s = 0;
        for (int i = 2; Math.Abs(a) >= e; ++i)
        {
            s += a;
            a = a * 9 / i;
        }
        Console.WriteLine("s={0:f8}", s);
    }
}
