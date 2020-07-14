using System;
using System.Collections.Generic;

namespace Sample.LS
{
    public class FlattenMultiList
    {

        public class Node
        {
            public Node prev {get;set;}
            public Node next {get;set;}

            public Node child {get;set;}

            public Node(int val)
            {
                this.val = val;
            }

            public int val;
        }
        public static FlattenMultiList Instance = new FlattenMultiList();

        Node _head;
        Node last;

        Stack<Node> stack = new Stack<Node>();

        private void Read()
        {
            Node n1 = new Node(1);
            Node n2 = new Node(2);
            Node n3 = new Node(3);
            Node n4 = new Node(4);
            Node n5 = new Node(5);
            Node n6 = new Node(6);
            Node n7 = new Node(7);
            Node n8 = new Node(8);
            Node n9 = new Node(9);
            Node n10 = new Node(10);
            Node n11 = new Node(11);
            Node n12 = new Node(12);

            _head = n1;
            // Link(n1, n2);
            // Link(n2, n3);
            // Link(n3, n4);
            // Link(n4, n5);
            // Link(n5, n6);

            // Link(n7, n8);
            // Link(n8, n9);
            // Link(n9, n10);

            // Link(n11, n12);

            n1.child = n2;
            n2.child = n3;
            n3.child = n4;
        }

        private void Link(Node n1, Node n2)
        {
            if(n1 != null) n1.next = n2;
            if(n2 != null) n2.prev = n1;
        }

        public void Do()
        {
            Read();
            Flatten(_head);
        }

        public Node Flatten(Node head)
        {
            if(head == null)
                return null;

            var node = head;

            while(node != null)
            {
                last = node;
                if(node.child != null)
                {
                    var temp = node.next;
                    Link(node, node.child);
                    Flatten(node.child);
                    Link(last, temp);
                    node.child = null;
                    node = temp;
                }
                else
                    node = node.next;
            }
            

            return head;
        }
    }
}