using System;
using System.IO;

namespace BinaryTreeTask
{
    public class BinaryTree
    {
        private class Node
        {
            public int inf;
            public Node left;
            public Node right;

            public Node(int nodeInf)
            {
                inf = nodeInf; //значение узла
                left = null; //левый потомок
                right = null; //правый потомок
            }

            public static void Add(ref Node r, int nodeInf)
            {
                if (r == null) //если корень или найдено местоположение узла
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)r.inf).CompareTo(nodeInf) > 0) // если добавляемое значение меньше текующего 
                        Add(ref r.left, nodeInf); //левое поддерево
                    else //иначе
                        Add(ref r.right, nodeInf); //правое поддерево
                }
            }

            public static void SumOnlyRight(Node node, ref int sum)
            {
                if (node == null) return;
                if (node.left == null && node.right != null) //нет левого, но есть правый потомок
                {
                    sum += (int)node.inf;
                }
                SumOnlyRight(node.left, ref sum);
                SumOnlyRight(node.right, ref sum);
            }
        }

        private Node tree;

        public void Add(int item)
        {
            Node.Add(ref tree, item); //местоположение нового узла определяется относительно корня дерева
        }

        public int AnswerSum() // метод для поиска суммы значений узлов в дереве, имеющих только одно правое поддерево
        {
            int sum = 0;
            Node.SumOnlyRight(tree, ref sum); //вспомогательный метод для проверки условия + рекурсии
            return sum;
        }
 
    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            using (StreamReader fileIn = new StreamReader("input2.txt"))
            {
                string content = fileIn.ReadToEnd();
                string[] numbers = content.Split();
                foreach (string num in numbers)
                {
                    tree.Add(int.Parse(num));
                }
            }

            int sum = tree.AnswerSum();
            Console.WriteLine("Cумма значений узлов в дереве, имеющих только одно правое поддерево: " + sum);
        }
    }
}