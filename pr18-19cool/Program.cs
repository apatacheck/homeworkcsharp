using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyProgram
{
    class Program
    {
        static void Main()
        {
            //List<Function> functions = new List<Function>();   // создаём пустой список, который будет хранить объекты функций

            //functions.Add(new Line(2, 1));         // добавляем в список объект прямой y = 2x + 1

            //functions.Add(new Kub(1, -3, 2));      // добавляем в список объект кубической функции y = x² - 3x + 2

            //functions.Add(new Hyperbola(4, 0));    // добавляем в список объект гиперболы y = 4/x

            //// Сохраняем в файл
            //string json1 = JsonSerializer.Serialize(functions, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText("functions.json", json1);

            // Читаем из файла
            string jsonText = File.ReadAllText("functions.json");
            List<Function> loaded = JsonSerializer.Deserialize<List<Function>>(jsonText);

            double x = 2.0;

            Console.WriteLine("=== До сортировки ===");
            foreach (var f in loaded)
            {
                Console.WriteLine(f.ToString());
                Console.WriteLine($"f({x}) = {f.Calculate(x)}");
                Console.WriteLine();
            }

            loaded.Sort();

            Console.WriteLine("=== После сортировки ===");
            foreach (var f in loaded)
            {
                Console.WriteLine(f.ToString());
                Console.WriteLine($"f({x}) = {f.Calculate(x)}");
                Console.WriteLine();
            }
            //string json2 = JsonSerializer.Serialize(loaded, new JsonSerializerOptions { WriteIndented = true });
            //File.WriteAllText("functions.json", json2);
        }
    }
}