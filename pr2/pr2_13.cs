using System;
class Practice2_13
{
    static void Main(string[] args)
    {
        Console.Write("Введите трехзначное число:");
        int x = int.Parse(Console.ReadLine()!);
        while (x < 100 || x > 999)
        {
            Console.WriteLine("Вы ввели не трехзначное число :,(");
            Console.Write("Введите трехзначное число:");
            x = int.Parse(Console.ReadLine()!);
        }

        int n1 = x / 100;
        int n2 = (x % 100) / 10;
        int answ = n1 >= n2 ? n1 : n2;
        Console.WriteLine("Наибольшая цифра:" + answ);





    }
}
