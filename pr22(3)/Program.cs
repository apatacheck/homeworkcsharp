
namespace pr22_3_
{
    class Program
    {
        static void Main()
        {
            Graph g = new Graph("input.txt");

            Console.WriteLine("Граф:");
            g.Show();
            Console.WriteLine();

            g.ShortestPath("Москва", "Калуга", "Владимир");

            Console.ReadKey();
        }
    }
}