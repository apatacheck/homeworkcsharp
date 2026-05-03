
namespace pr22
{
    class Program
    {
        static void Main()
        {
            Graph g = new Graph("input1.txt");
            
            Console.WriteLine("Graph:");
            g.Show();
            Console.WriteLine("Введите номер вершины, для которой нужно найти смежные:");
            int v = int.Parse(Console.ReadLine()!);
            g.Neighbouring(v);
            
            Console.ReadKey();
        }
    }
}