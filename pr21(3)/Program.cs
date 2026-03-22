using System;
using System.IO;
//АВЛ-дерево — это самобалансирующееся двоичное дерево поиска,
//в котором для каждого узла высота левого и правого поддеревьев
//отличается не более чем на 1.
namespace AVLSubtreeCheck
{
    public class AVLTree
    {
        private class Node
        {
            public int inf; //информационное поле
            public int height; //высота поддерева с корнем в данном узле
            public Node left; //ссылка на левое поддерево
            public Node right; //ссылка на правое поддерево

            public Node(int nodeInf)
            {
                inf = nodeInf;
                height = 1;
                left = null;
                right = null;
            }

            //возвращает высоту узла, в том числе и пустого
            public int Height
            {
                get
                {
                    return (this != null) ? this.height : 0;
                }
            }

            //возвращает разницу высот правого и левого поддерева для заданного узла
            public int BalanceFactor
            {
                get
                {
                    int rh = (this.right != null) ? this.right.Height : 0;
                    int lh = (this.left != null) ? this.left.Height : 0;
                    return rh - lh;
                }
            }

            //пересчитывает высоту узла
            public void NewHeight()
            {
                int rh = (this.right != null) ? this.right.Height : 0;
                int lh = (this.left != null) ? this.left.Height : 0;
                this.height = ((rh > lh) ? rh : lh) + 1;
            }

            //правый поворот
            public static void RotationRight(ref Node t)
            {
                Node x = t.left;
                t.left = x.right;
                x.right = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }

            //левый поворот
            public static void RotationLeft(ref Node t)
            {
                Node x = t.right;
                t.right = x.left;
                x.left = t;
                t.NewHeight();
                x.NewHeight();
                t = x;
            }

            //балансировка узла
            public static void Balance(ref Node t)
            {
                t.NewHeight();
                if (t.BalanceFactor == 2) //узел нужно повернуть влево, т.к. его правое поддерево перегружено
                {
                    if (t.right.BalanceFactor < 0) //проверка условия выполнения большого поворота налево
                    {
                        RotationRight(ref t.right);
                    }
                    RotationLeft(ref t);
                }
                if (t.BalanceFactor == -2) //узел нужно повернуть вправо, т.к. его левое поддерево перегружено
                {
                    if (t.left.BalanceFactor > 0) 
                    {
                        RotationLeft(ref t.left);
                    }
                    RotationRight(ref t);
                }
            }

            //добавляет узел в дерево так, чтобы дерево оставалось АВЛ-деревом
            public static void Add(ref Node r, int nodeInf)
            {
                if (r == null) //если корень или найдено местоположение узла
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (r.inf.CompareTo(nodeInf) > 0) //если добавляемое значение меньше текущего
                    {
                        Add(ref r.left, nodeInf); //спускаемся по левому поддереву
                    }
                    else //иначе
                    {
                        Add(ref r.right, nodeInf); //спускаемся по правому поддереву
                    }
                    Balance(ref r); //балансируем текущий узел при возвращении из рекурсии
                }
            }

            //проверяет, является ли дерево b поддеревом дерева a
            public static void IsSubtree(Node a, Node b, ref bool result)
            {
                if (result) return; //если уже нашли- выходим
                if (b == null) //пустое дерево является поддеревом любого дерева
                {
                    result = true;
                    return;
                }
                if (a == null) //если дерево a пустое, а b не пустое, то не поддерево
                {
                    return;
                }

                //если значения корней совпадают, проверяем идентичность поддеревьев
                if (a.inf == b.inf)
                {
                    bool identical = true;
                    IsIdentical(a, b, ref identical); //проверяем полное совпадение
                    if (identical) //если деревья идентичны
                    {
                        result = true;
                        return;
                    }
                }

                //рекурсивно проверяем левое и правое поддеревья
                IsSubtree(a.left, b, ref result);
                IsSubtree(a.right, b, ref result);
            }

            //проверяет полную идентичность двух деревьев 
            public static void IsIdentical(Node a, Node b, ref bool result)
            {
                if (!result) return; //если уже нашли false - выходим
                if (a == null && b == null) //оба узла пустые - идентичны
                {
                    return;
                }
                if (a == null || b == null) //один узел пустой, другой нет - не идентичны
                {
                    result = false;
                    return;
                }

                //сравниваем значения узлов
                if (a.inf != b.inf)
                {
                    result = false;
                    return;
                }

                //рекурсивно проверяем левое и правое поддеревья
                IsIdentical(a.left, b.left, ref result);
                IsIdentical(a.right, b.right, ref result);
            }
        }

        private Node tree; //ссылка на корень дерева

        //открытый конструктор
        public AVLTree()
        {
            tree = null;
        }

        //добавление узла в дерево
        public void Add(int item)
        {
            Node.Add(ref tree, item); 
        }

        //проверяет, является ли дерево other поддеревом текущего дерева
        public bool IsSubtree(AVLTree other)
        {
            bool result = false;
            Node.IsSubtree(this.tree, other.tree, ref result);
            return result;
        }

        //проверяет, является ли текущее дерево поддеревом дерева other
        public bool IsSubtreeOf(AVLTree other)
        {
            bool result = false;
            Node.IsSubtree(other.tree, this.tree, ref result);
            return result;
        }

        //проверяет полную идентичность двух деревьев
        public bool IsIdentical(AVLTree other)
        {
            bool result = true;
            Node.IsIdentical(this.tree, other.tree, ref result);
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AVLTree treeA = new AVLTree(); 
            AVLTree treeB = new AVLTree(); 

            //на основе данных файла input1.txt создаем дерево A
            using (StreamReader fileIn = new StreamReader("input7.txt"))
            {
                string content = fileIn.ReadToEnd();
                string[] numbers = content.Split();
                foreach (string num in numbers)
                {
                    treeA.Add(int.Parse(num));
                }
            }

            //на основе данных файла input2.txt создаем дерево B
            using (StreamReader fileIn = new StreamReader("input8.txt"))
            {
                string content = fileIn.ReadToEnd();
                string[] numbers = content.Split();
                foreach (string num in numbers)
                {
                    treeB.Add(int.Parse(num));
                }
            }

            //проверяем, является ли дерево B поддеревом дерева A
            if (treeA.IsSubtree(treeB))
            {
                Console.WriteLine("Дерево B является поддеревом дерева A");
            }
            else
            {
                Console.WriteLine("Дерево B НЕ является поддеревом дерева A");
            }

            //проверяем, является ли дерево A поддеревом дерева B
            if (treeB.IsSubtree(treeA))
            {
                Console.WriteLine("Дерево A является поддеревом дерева B");
            }
            else
            {
                Console.WriteLine("Дерево A НЕ является поддеревом дерева B");
            }

            //проверяем полную идентичность деревьев
            if (treeA.IsIdentical(treeB))
            {
                Console.WriteLine("Деревья A и B полностью идентичны");
            }
        }
    }
}