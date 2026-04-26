
//I.В входном файле указывается количество вершин графа/орграфа и матрица смежности:Для взвешенного графа:
//14.подсчитать количество вершин, смежных с данной;

namespace pr22
{
    public class Graph
    {
        private class Node
        {
            private int[,] array; //матрица смежности
            public int this[int i, int j]
            {
                get { return array[i, j]; }
                set { array[i, j] = value; }
            }
            public int Size
            {
                get { return array.GetLength(0); }
            }

            public Node(int[,] a)
            {
                array = a;
            }
        }

        private Node graph;

        public Graph(string name)
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine()!);
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine()!;
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }
                graph = new Node(a);
            }
        }

        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }

   
        public void Neighbouring(int v)
        {
            Console.Write("Вершины смежные с {0} вершиной: ", v);
            int count = 0;
            for (int i = 0; i < graph.Size; i++)
            {
                if (graph[v, i] != 0)
                {
                    Console.Write("{0} ", i);
                    count++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Количество смежных вершин: {0}", count);

        }
    }
}