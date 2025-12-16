using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

//Задание 14. На основе данных входного файла составить инвентарную ведомость
//игрушек, включив следующие данные: название игрушки, ее стоимость (в руб.), возрастные
//границы детей, для которых предназначена игрушка. Вывести в новый файл информацию о
//тех игрушках, которые предназначены для детей от N до M лет, сгруппировав их по
//названию.
struct Toy
{
    public string Name;
    public double Price;
    public int minAge;
    public int maxAge;

    public Toy(string Name, double Price, int minAge, int maxAge)
    {
        this.Name = Name;
        this.Price = Price;
        this.minAge = minAge;
        this.maxAge = maxAge;
    }
}

class Program
{
    public static List<Toy> Input(string fileName)
    {
        using (StreamReader fileInput = new StreamReader(fileName))
        {
            List<Toy> toyList = new List<Toy>();

            string? line;
            while ((line = fileInput.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(';');
                string name = parts[0];
                double price = double.Parse(parts[1]);
                int minAge = int.Parse(parts[2]);
                int maxAge = int.Parse(parts[3]);
                toyList.Add(new Toy(name, price, minAge, maxAge));
          
            }
            return toyList;
        }
    }

    public static void Main()
    {
        Console.Write("Введите минимальный возраст N: ");
        int N = int.Parse(Console.ReadLine()!);

        Console.Write("Введите максимальный возраст M: ");
        int M = int.Parse(Console.ReadLine()!);

        List<Toy> toys = Input("test1.txt");

        var groupedToys = toys.Where(t => t.minAge <= N && t.maxAge >= M).GroupBy(t => t.Name).OrderBy(g => g.Key); // для детей от N до M лет. сгруппировав их по названию.

        using (StreamWriter fileOut = new StreamWriter("output.txt"))
        {
            foreach (var group in groupedToys)
            {
                fileOut.WriteLine($"Название: {group.Key}");
                foreach (var toy in group)
                {
                    fileOut.WriteLine($"Цена: {toy.Price}; Мин.возраст: {toy.minAge}; Макс.возраст: {toy.maxAge}");
                }

                fileOut.WriteLine();
            }
        }

        Console.WriteLine("Результат записан в output.txt");
    }
}
