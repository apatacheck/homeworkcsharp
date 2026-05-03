//II. В входном файле указывается количество вершин графа/орграфа и матрица смежности:
//Для заданного графа: определить все пары вершин, для которых существует путь длиной не более L;

namespace pr22_2_
{
    public class Graph
    {
        private class Node
        {
            private int[,] array;
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

            public long[,] Floyd()
            {
                int i, j, k;
                long[,] a = new long[Size, Size];

                for (i = 0; i < Size; i++)
                {
                    for (j = 0; j < Size; j++)
                    {
                        if (i == j)
                        {
                            a[i, j] = 0;
                        }
                        else
                        {
                            if (array[i, j] == 0)
                            {
                                a[i, j] = int.MaxValue;
                            }
                            else
                            {
                                a[i, j] = array[i, j];
                            }
                        }
                    }
                }

                for (k = 0; k < Size; k++)
                {
                    for (i = 0; i < Size; i++)
                    {
                        for (j = 0; j < Size; j++)
                        {
                            long distance = a[i, k] + a[k, j];
                            if (a[i, j] > distance)
                            {
                                a[i, j] = distance;
                            }
                        }
                    }
                }
                return a;
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

        public void PrintPairsWithinDistance(int L)
        {
            long[,] dist = graph.Floyd();
            int n = graph.Size;

            bool found = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (dist[i, j] <= L)
                    {
                        Console.WriteLine("({0}, {1}) -длина пути = {2}", i, j, dist[i, j]);
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Нет пар вершин с путем длиной не более {0}", L);
            }
        }
    }
}