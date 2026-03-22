using System;
using System.IO;

// Вариант 3: После каждого элемента со значением х вставить элемент со значением у.
public class List
    {
        private class Node // Класс элемента списка
        {
            private int inf; //значение элемента
            private Node next; //ссылка на следующий элемент

            public Node(int nodeInfo)
            {
                inf = nodeInfo;
                next = null;
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public int Inf
            {
                get { return inf; }
                set { inf = value; }
            }
        }

        private Node head;
        private Node tail;

        public List() //инициализация списка
        {
            head = null;
            tail = null;

        }

        public void AddEnd(int nodeInfo) //добавление в конец
        {
            Node temp = new Node(nodeInfo);
            if (head == null)
            {
                head = temp;
                tail = temp;
            }
            else
            {
                tail.Next = temp; //переназначение ссылки после хвоста на temp
                tail = temp; //хвост - последний добавленный элемент
            }
        }

        public int TakeBegin() // извлечение из головы
        {
            if (head == null)
                throw new Exception("Список пуст");

            int value = head.Inf; //сохраняем inf головы для возвращения
            head = head.Next; // голова - следующий после бывшей головы элемент
            if (head == null)
                tail = null;
            return value;
        }

    public void Insert(int x, int y) //После каждого элемента со значением х вставить элемент со значением у
        {
            if (head == null) return;

            Node temp = head;
            while (temp != null)
            {
                if (((IComparable)temp.Inf).CompareTo(x) == 0)  //проходимся по List и ищем элемент с inf = x
                {
                    Node newNode = new Node(y);
                    newNode.Next = temp.Next; // ссылка на следующий элемент после newNode устанавливаем на следующий элемент после x
                    temp.Next = newNode; //ссылка на элемент после temp указывает newNode 
                    //т.е. newNode вставляется после temp. newNode ссылается на элемент, который раньше находился после temp,а temp ссылается на newNode
                    if (temp == tail)
                    {
                        tail = newNode;
                    }

                    temp = newNode.Next; // переход к следующему элементу после вставленного 
                }
                else
                {
                    temp = temp.Next; //проход по списку дальше, если элемент с нужным значением не нашли
                }
            }
        }

        public void Show()
        {
            Node temp = head;
            while (temp != null)
            {
                Console.Write(temp.Inf + " ");
                temp = temp.Next;
            }
            Console.WriteLine();
        }

    public void WriteToFile(StreamWriter fileOut) //метод для записи списка в файл
        {
            Node temp = head;
            while (temp != null)
            {
                fileOut.Write(temp.Inf + " ");
                temp = temp.Next;
            }
        }
    }

    public class Program
    {
        static void Main()
        {
         
            string[] originalNumbers; 
            using (StreamReader fileIn = new StreamReader("input.txt")) //читаем файл с числами
            {
                string content = fileIn.ReadToEnd();
                originalNumbers = content.Split();
                                               
            }


            using (StreamWriter fileOut = new StreamWriter("output.txt")) // переписываем исходный список в файл
            {
                foreach (string num in originalNumbers)
                    fileOut.Write(num + " ");
                fileOut.WriteLine();
            }


            List list = new List();
            foreach (string num in originalNumbers) // создание List 
                list.AddEnd(int.Parse(num));

            Console.Write("Введите число для поиска x=");
            int x = int.Parse(Console.ReadLine()!);
            Console.Write("Введите число для вставки y=");
            int y = int.Parse(Console.ReadLine()!);     
            Console.WriteLine("\nИсходный список:");
            list.Show();
            list.Insert(x, y); 
            Console.WriteLine("\nИзмененный список:");
            list.Show();

       
            using (StreamWriter fileOut = new StreamWriter("output.txt", true)) //вписываем измененный список в файл
            {
                list.WriteToFile(fileOut);
            }

            Console.WriteLine("\nРезультат записан в output.txt");
        }
    }
