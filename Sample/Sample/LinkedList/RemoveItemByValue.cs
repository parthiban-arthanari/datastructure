using System;

namespace Sample.LS
{
    public class RemoveItemByValue
    {
        public static RemoveItemByValue Instance = new RemoveItemByValue();

        Node Head;
        private void Read()
        {
            Head = new Node(1);

            Node n2 = new Node(1);
            Node n3 = new Node(3);
            Node n4 = new Node(6);
            Node n5 = new Node(5);
            Node n6 = new Node(7);
            Node n7 = new Node(6);

            Head.Next = n2;
            // n2.Next = n3;
            n3.Next = n4;
            n4.Next = n5;
            n5.Next = n6;
            n6.Next = n7;
        }

        public void Do()
        {
            Read();
            var val = Remove(Head, 1);
        }

        private Node Remove(Node head, int val)
        {
            Node temp = new Node(0);
            temp.Next = head;
            Node curr = head;
            Node prev = temp;

            while(curr != null)
            {
                if(curr.Value == val) prev.Next = curr.Next;
                else prev = curr;
                curr = curr.Next;
            }

            return temp.Next;
        }
    }
}