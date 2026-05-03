
namespace pr22_2_
{
    class Program
    {
        static void Main()
        {
            Graph g = new Graph("input.txt");
            Console.WriteLine("Граф:");
            g.Show();
            Console.WriteLine();
            Console.Write("Введите L: ");
            int L = int.Parse(Console.ReadLine()!);
            g.PrintPairsWithinDistance(L);

            Console.ReadKey();
        }
    }
}