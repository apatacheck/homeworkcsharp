using System;
using System.Linq;
using System.IO;
//Вывести на экран в порядке возрастания все элементы, меньшие заданного числа,
//увеличив их в три раза
class Program
{
    static void Main()
    {
        Console.Write("Введите key: ");
        int key = int.Parse(Console.ReadLine()!);
        int[] numbers = File.ReadAllText("input.txt").Split().Select(int.Parse).ToArray();

        var result = numbers.Where(n => n < key).OrderBy(n => n).Select(x => x > 0 ? x * 3 : x / 3); 

        var resultString = string.Join(" ", result);
        File.WriteAllText("output.txt", resultString);

        Console.WriteLine("Отсортирован и отправлен в output.txt!");
        Console.WriteLine(resultString);
    }
}