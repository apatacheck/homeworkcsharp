using System;
using System.IO;

namespace Example
{
    public class Node
    {
        private object inf;
        private Node next;

        public Node(object nodeInfo)
        {
            inf = nodeInfo;
            next = null;
        }

        public Node Next
        {
            get { return next; }
            set { next = value; }
        }

        public object Inf
        {
            get { return inf; }
            set { inf = value; }
        }
    }

    public class List
    {
        private Node head;
        private Node tail;
        private Node temp;

        public List()
        {
            head = null;
            tail = null;
            temp = null;
        }

        public void AddEnd(object nodeInfo)
        {
            temp = new Node(nodeInfo);
            if (head == null)
            {
                head = temp;
                tail = temp;
            }
            else
            {
                tail.Next = temp;
                tail = temp;
            }
        }

        public object TakeBegin()
        {
            if (head == null)
                throw new Exception("Список пуст");

            temp = head;
            head = head.Next;
            if (head == null)
                tail = null;

            object value = temp.Inf;
            return value;
        }

        public Node GetHead()
        {
            return head;
        }


        public void Insert(object x, object y)
        {
            if (head == null) return;  // пустой список

            temp = head;  // используем temp для обхода

            while (temp != null)
            {
                if (((IComparable)temp.Inf).CompareTo(x) == 0)
                {
                    // Создаем новый узел
                    Node newNode = new Node(y);

                    // Вставляем после temp
                    newNode.Next = temp.Next;
                    temp.Next = newNode;

                    // Если вставляли в конец, обновляем tail
                    if (temp == tail)
                    {
                        tail = newNode;
                    }

                    // Переходим через вставленный элемент
                    temp = newNode.Next;
                }
                else
                {
                    temp = temp.Next;
                }
            }
        }

        public void Show()
        {
            temp = head;
            while (temp != null)
            {
                Console.Write(temp.Inf + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        public List Copy()
        {
            List newList = new List();
            temp = head;
            while (temp != null)
            {
                newList.AddEnd(temp.Inf);
                temp = temp.Next;
            }
            return newList;
        }
    }

    public class Program
    {
        static void Main()
        {
            List list = new List();

            using (StreamReader fileIn = new StreamReader("input.txt"))
            {
                string content = fileIn.ReadToEnd();
                string[] numbers = content.Split(new char[] { ' ', '\t', '\n', '\r' },
                                                StringSplitOptions.RemoveEmptyEntries);
                foreach (string num in numbers)
                    list.AddEnd(int.Parse(num));
            }


            List originalList = list.Copy();

            Console.Write("Введите число для поиска x=");
            int x = int.Parse(Console.ReadLine()!);
            Console.Write("Введите число для вставки y=");
            int y = int.Parse(Console.ReadLine()!);

            Console.WriteLine("\nИсходный список:");
            originalList.Show();


            Node current = list.GetHead();
            while (current != null)
            {
                if (((IComparable)current.Inf).CompareTo(x) == 0)
                {
                    Node newNode = new Node(y);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                    current = newNode.Next;
                }
                else
                {
                    current = current.Next;
                }
            }

            Console.WriteLine("\nИзмененный список:");
            list.Show();

            using (StreamWriter fileOut = new StreamWriter("output.txt"))
            {
                void WriteListToFile(List source)
                {
                    Node node = source.GetHead();
                    while (node != null)
                    {
                        fileOut.Write(node.Inf + " ");
                        node = node.Next;
                    }
                }

                WriteListToFile(originalList);
                fileOut.WriteLine();
                WriteListToFile(list);
            }

            Console.WriteLine("\nРезультат записан в output.txt");
        }

    }
}
