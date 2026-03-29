using System;
using System.IO;
using System.Net.Security;
//13. найти сумму узлов c четным значением, расположенных на k-уровне;
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

            public static void SumEvenAtLevel(Node t, int level, int k, ref int sum)
            {
                if (t != null)
                {
                    if (level == k && t.inf % 2 == 0) // найти сумму узлов с четным значением, расположенных на k-м уровне;
                    {
                        Console.WriteLine("Узел: " + t.inf + "Сумма: " + sum);
                        sum += t.inf;
         
                    }

                    SumEvenAtLevel(t.left, level + 1, k, ref sum);
                    SumEvenAtLevel(t.right, level + 1, k, ref sum);
                }
            }
        }

        private Node tree;

        public void Add(int item)
        {
            Node.Add(ref tree, item); //местоположение нового узла определяется относительно корня дерева
        }
        public int AnswerSum(int k)
        {
            int sum = 0;
            Node.SumEvenAtLevel(tree, 0, k, ref sum);
            return sum;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();

            using (StreamReader fileIn = new StreamReader("input4.txt"))
            {
                string content = fileIn.ReadToEnd();
                string[] numbers = content.Split();
                foreach (string num in numbers)
                {
                    tree.Add(int.Parse(num));
                }
            }
            Console.Write("Введите уровень дерева: ");
            int level = int.Parse(Console.ReadLine()!);
            int sum = tree.AnswerSum(level);
            Console.WriteLine("Cумма узлов с четным значением, расположенных на уровне " + level + ": " + sum);
        }
    }
}
