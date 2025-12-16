using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
//На основе данных входного файла составить инвентарную ведомость
//игрушек, включив следующие данные: название игрушки, ее стоимость (в руб.), возрастные
//границы детей, для которых предназначена игрушка. Вывести в новый файл информацию о
//тех игрушках, которые предназначены для детей старше N лет, отсортировав их по
//стоимости.

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
            string line = fileInput.ReadLine()!;
            while ((line = fileInput.ReadLine()!) != null)
            {
                var parts = line.Split(";");
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
        Console.Write("Введите возраст N: ");
        int Age = int.Parse(Console.ReadLine()!);

        List<Toy> Toys = Input("test.txt");
        var corrToys =
            from toy in Toys
            where toy.minAge > Age //предназначены для детей старше N лет
            orderby toy.Price  //отсортировав по cтоимости
            select toy;

        using (StreamWriter fileOut = new StreamWriter("output.txt"))
        {
           foreach (var toy in corrToys)
           {
                fileOut.WriteLine($"Название: {toy.Name}; Цена: {toy.Price}; Мин.возраст: {toy.minAge}; Макс.возраст: {toy.maxAge}");
           }
            
        }
        Console.WriteLine("Результат записан в output.txt");
    }
}