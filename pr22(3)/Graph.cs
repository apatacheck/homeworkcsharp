namespace pr22_3_
{
    public class Graph
    {
        private class Node
        {
            private int[,] array;
            private string[] names;
            private int[] x, y;
            private bool[] nov;

            public int this[int i, int j]
            {
                get { return array[i, j]; }
                set { array[i, j] = value; }
            }

            public int Size
            {
                get { return array.GetLength(0); }
            }

            public string GetName(int i)
            {
                return names[i];
            }

            public void NovSet()
            {
                for (int i = 0; i < Size; i++)
                    nov[i] = true;
            }

            public bool NovGet(int i)
            {
                return nov[i];
            }

            public void SetNov(int i, bool value)
            {
                nov[i] = value;
            }

            public Node(int n, string[] nameArr, int[] xArr, int[] yArr, int[,] adj)
            {
                array = adj;
                names = nameArr;
                x = xArr;
                y = yArr;
                nov = new bool[n];
            }

            private double GetWeight(int i, int j)
            {
                double dx = x[i] - x[j];
                double dy = y[i] - y[j];
                return Math.Sqrt(dx * dx + dy * dy);
            }

 
            public double[] Dijkstr(int v, out int[] p)
            {
                nov[v] = false;

                double[,] c = new double[Size, Size]; //матрица весов
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        if (array[i, u] == 0 || i == u)
                        {
                            c[i, u] = double.PositiveInfinity; 
                        }
                        else
                        {
                            c[i, u] = GetWeight(i, u);
                        }
                    }
                }

                double[] d = new double[Size]; //массив для храненяи расстояний
                p = new int[Size]; //хранение пути

                for (int u = 0; u < Size; u++)
                {
                    if (u != v)
                    {
                        d[u] = c[v, u];
                        p[u] = v;
                    }
                }

                for (int i = 0; i < Size - 1; i++)
                {
                    double min = double.PositiveInfinity;
                    int w = 0;
                    for (int u = 0; u < Size; u++)
                    {
                        if (nov[u] && min > d[u]) //ищем вершину с минимальным расстоянием
                        {
                            min = d[u];
                            w = u;
                        }
                    }
                    nov[w] = false;

                    for (int u = 0; u < Size; u++)
                    {
                        double distance = d[w] + c[w, u]; //путь через вершину w
                        if (nov[u] && d[u] > distance)
                        {
                            d[u] = distance;
                            p[u] = w;
                        }
                    }
                }

                return d; 
            }

            public void WayDijkstr(int a, int b, int[] p, ref Stack items)
            {
                items.Push(b);
                if (a == p[b])
                {
                    items.Push(a);
                }
                else
                {
                    WayDijkstr(a, p[b], p, ref items);
                }
            }
        }

        private Node graph;

        public Graph(string name)
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                string[] names = new string[n];
                int[] x = new int[n];
                int[] y = new int[n];

                for (int i = 0; i < n; i++)
                {
                    string[] parts = file.ReadLine().Split(' ');
                    names[i] = parts[0];
                    x[i] = int.Parse(parts[1]);
                    y[i] = int.Parse(parts[2]);
                }

                int[,] adj = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string[] parts = file.ReadLine().Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        adj[i, j] = int.Parse(parts[j]);
                    }
                }

                graph = new Node(n, names, x, y, adj);
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

        public int GetCityIndex(string name)
        {
            for (int i = 0; i < graph.Size; i++)
                if (graph.GetName(i) == name)
                    return i;
            return -1;
        }

        public void ShortestPath(string startName, string endName, string forbiddenCity)
        {
            int start = GetCityIndex(startName);
            int end = GetCityIndex(endName);
            int forbidden = GetCityIndex(forbiddenCity);

            graph.NovSet();
            graph.SetNov(forbidden, false);

            int[] p;
            double[] d = graph.Dijkstr(start, out p);  

            if (d[end] == double.PositiveInfinity)
            {
                Console.WriteLine("Пути из {0} в {1} не существует", startName, endName);
                return;
            }

            Console.WriteLine("Длина кратчайшего пути от вершины {0} до вершины {1}", startName, endName);
            Console.Write("Длина = {0:F2}, путь: ", d[end]);

            Stack items = new Stack();
            graph.WayDijkstr(start, end, p, ref items);
            while (!items.IsEmpty)
            {
                Console.Write("{0} ", graph.GetName(items.Pop()));
            }
            Console.WriteLine();
        }
    }
}