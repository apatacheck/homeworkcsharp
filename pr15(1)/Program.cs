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

        var numbers = File.ReadAllText("input1.txt").Split();

        var result =
            from x in numbers
            let n = int.Parse(x)
            where n < key
            orderby n
            select n * 3;

        File.WriteAllText("output.txt", string.Join(" ", result));

        Console.WriteLine("Отсортирован и отправлен в output.txt!");
    }
}
