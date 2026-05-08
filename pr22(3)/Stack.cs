namespace pr22_3_
{
    public class Stack
    {
        private class Node
        {
            public int data;
            public Node next;
            public Node(int d) { data = d; next = null; }
        }

        private Node head;

        public Stack()
        {
            head = null;
        }

        public bool IsEmpty
        {
            get { return head == null; }
        }

        public void Push(int value)
        {
            Node newNode = new Node(value);
            newNode.next = head;
            head = newNode;
        }

        public int Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            int value = head.data;
            head = head.next;
            return value;
        }
    }
}