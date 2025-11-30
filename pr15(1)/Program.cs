using System;
using System.Linq;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        Console.Write("Введите key: ");
        int key = int.Parse(Console.ReadLine()!);

        var numbers = File.ReadAllText(inputPath).Split( ' ', StringSplitOptions.RemoveEmptyEntries);

        var result =
            from x in numbers
            let n = int.Parse(x)
            where n < key
            orderby n
            select n * 3;

        File.WriteAllText(outputPath, string.Join(" ", result));

        Console.WriteLine("Отсортирован и отправлен в output.txt!");
    }
}
