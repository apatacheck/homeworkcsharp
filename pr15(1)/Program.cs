using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введите key: ");
        int key = int.Parse(Console.ReadLine()!);

        int[] numbers = File.ReadAllText("input.txt").Split().Select(int.Parse).ToArray();


        var result =
            from x in numbers
            where x < key
            orderby x
            select x >= 0 ? x * 3 : x / 3;

        var resultString = string.Join(" ", result);
        File.WriteAllText("output.txt", resultString);

        Console.WriteLine("Отсортирован и отправлен в output.txt!");
        Console.WriteLine(resultString);
    }
}