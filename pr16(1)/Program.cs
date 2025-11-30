using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Введите key: ");
        int key = int.Parse(Console.ReadLine()!);

        var numbers = File.ReadAllText("input1.txt").Split();

        var result = numbers
            .Select(x => int.Parse(x))
            .Where(n => n < key)
            .OrderBy(n => n)
            .Select(n => n * 3);

        File.WriteAllText("output.txt", string.Join(" ", result));

        Console.WriteLine("Отсортирован и отправлен в output.txt!");
    }
}