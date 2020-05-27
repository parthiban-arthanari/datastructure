using System;
using System.Collections.Generic;
using Sample;
using Sample.LS;

namespace Sample.DayChallenge
{
    public class MiddleOfLinkedList
    {
        public static MiddleOfLinkedList Instance = new MiddleOfLinkedList();
        LinkedList List;

        private void Read()
        {
            List = new LinkedList();

            List.AddNode(new Node(1));
            List.AddNode(new Node(2));
            List.AddNode(new Node(3));
            List.AddNode(new Node(4));
            List.AddNode(new Node(5));

        }

        public void Do()
        {
            Read();
            Console.WriteLine("Middle of the Node - {0}", MiddleNode(List.Head).Value);
        }

        private Node MiddleNode(Node head)
        {
            Node slowHead = head;
            Node fastHead = head;

            while(fastHead != null && fastHead.Next != null)
            {
                slowHead = slowHead.Next;
                fastHead = fastHead.Next.Next;
            }

            return slowHead;
        }
    }
}
