using System;
using System.IO;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

// Вывести в новый файл информацию о тех пассажирах, средний вес багажа которых
// превышает заданный, отсортировав их по количеству вещей, сданных в камеру хранения
struct Passenger : IComparable<Passenger>
{
    public string fullName;
    public int Items;
    public double Weight;

    public Passenger(string fullName, int Items, double Weight)
    {
        this.fullName = fullName;
        this.Items = Items;
        this.Weight = Weight;
    }

    public double AvgWeight()
    {
        return this.Weight / this.Items;
    }

    public void Show()
    {
        Console.WriteLine($"Имя: {this.fullName}; вещей: {this.Items}; общий вес: {this.Weight}; средний вес: {this.AvgWeight():F3};");
    }

    public int CompareTo(Passenger other)
    {
        if (this.Items == other.Items)
        {
            return 0;
        }
        else
        {
            return this.Items < other.Items ? 1 : -1;
        }
    }

    class Program
    {
        static public Passenger[] Input()
        {
            using (StreamReader fileInput = new StreamReader("test.txt"))
            {
                int n = int.Parse(fileInput.ReadLine()!);
                Passenger[] arr = new Passenger[n];
                for (int i = 0; i < n; i++)
                {
                    string[] parts = fileInput.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    string fullName = parts[0] + " " + parts[1] + " " + parts[2];
                    int Items = int.Parse(parts[3]);
                    double Weight = double.Parse(parts[4]);
                    arr[i] = new Passenger(fullName, Items, Weight);
                }
                return arr;

            }

        }

        static void Print(Passenger[] array)
        {
            foreach (Passenger p in array)
                p.Show();
        }

        static void Main()
        {
            Console.WriteLine("Введите минимальный средний вес:");
            double minAvg = double.Parse(Console.ReadLine()!);
            Passenger[] array = Input();
            Passenger[] filteredArray = Array.FindAll(array, p => p.AvgWeight() > minAvg);
            Array.Sort(filteredArray);


            using (StreamWriter fileOut = new StreamWriter("output.txt"))
            {
                foreach (Passenger p in filteredArray)
                {
                    fileOut.WriteLine($"{p.fullName}; вещей: {p.Items}; общий вес: {p.Weight}; средний вес: {p.AvgWeight():F3}");
                }
            }

            Console.WriteLine("\nПассажиры, удовлетворяющие условию:");
            Print(filteredArray);

            Console.WriteLine("\nРезультат записан в output.txt");
        }
    }
}

