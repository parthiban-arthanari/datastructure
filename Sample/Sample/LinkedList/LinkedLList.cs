using System;
namespace Sample.LS
{
    public class Linked
    {
        public LinkedList List1 = new LinkedList();
        public LinkedList List2 = new LinkedList();
        public MultiList Multi = new MultiList();
        public void GetList()
        {
            //Console.WriteLine("Enter the list elements(to break enter -1");

            //while (true)
            //{
            //    var val = int.Parse(Console.ReadLine());

            //    if (val == -1)
            //        break;
            //    else
            //        List.AddNode(new Node(val));
            //}

            List1.AddNode(new Node(1));
            List1.AddNode(new Node(2));
            Node toLink = new Node(3);
            List1.AddNode(toLink);
            List1.AddNode(new Node(4));
            List1.AddNode(new Node(5));

            List1.AddNode(toLink);



        }

        public void CreateTwoList()
        {
            List1.AddNode(new Node(3));
            List1.AddNode(new Node(5));
            List1.AddNode(new Node(6));
            List1.AddNode(new Node(7));

            List2.AddNode(new Node(8));
            List2.AddNode(new Node(9));
            List2.AddNode(new Node(3));
        }

        public void CreateMultiList()
        {
            Multi.AddNode(new Node(5));
            Multi.AddNode(new Node(7));
            Multi.AddNode(new Node(8));

            Multi.AddList(new Node(10));
            Multi.AddNode(new Node(12));
            Multi.AddNode(new Node(15));

            Multi.AddList(new Node(20));
            Multi.AddNode(new Node(22));
            Multi.AddNode(new Node(25));

            Multi.Traverse();
        }

        public void AddtwoLinkedList()
        {
            CreateTwoList();
            addLinkList(List1.Head, List2.Head);
        }

        public void AddNodeCircularList()
        {
            CircularLinkList cir = new CircularLinkList();
            Node n = new Node(1);
            cir.AddNode(n);
            //cir.AddNode(new Node(1));
            cir.AddNode(new Node(2));
            cir.AddNode(new Node(3));
            cir.AddNode(new Node(4));
            //cir.AddNode(n);

            cir.Traverse();
        }

        public void FindLoopLength()
        {
            GetList();

            Node loopPoint = GetLoopPoint();
            Console.WriteLine("Length of Loop: {0}", GetLoopLength(loopPoint, loopPoint));
        }

        public Node GetLoopPoint()
        {
            Node slow = List1.Head;
            Node fast = List1.Head.Next;

            while(slow.Value != fast.Value)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return slow;
        }

        public int GetLoopLength(Node slow, Node fast)
        {
            int count = 1;
            fast = fast.Next;

            while (slow.Value != fast.Value)
                count++;

            return count;
        }

        public Node addLinkList(Node head1, Node head2)
        {
            Node newList = new Node(0);
            Node temp = newList;

            int carry = 0 ;
            while (head1 != null || head2 != null)
            {
                int head1Value = head1 == null ? 0 : head1.Value;
                int head2Value= head2 == null ? 0 : head2.Value;

                int sum = head1Value + head1Value + carry;
                carry = sum / 10;
                int tempValue = sum % 10;
                Node tempNode = new Node(tempValue);
                temp.Next = tempNode;
                head1 = head1.Next;
                head2 = head2.Next;
            }

            return newList;

        }

        public void KillPlayerAndPass(int option)
        {
            //CircularLinkList cir = new CircularLinkList();
            //Node current = cir.Tail.Next
            //while(current != cir.Tail)
            //{
            //    for(int i=0; i<option; i++)
            //    {

            //    }
            //}
        }
   
    }

    public class Node
    {
        public Node Next { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }

        public Node(int n)
        {
            Value = n;
        }
    }
    
    public class LinkedList

    {
        public Node Head;
        
        //public Node Tail;
        public int count;

            
        public void AddNode(Node n)
        {
            if (Head == null)
            {
                Head = n;
            }

            else
            {
                LastNode().Next = n;
            }
            count++;
        }

        public int GetCount()
        {
            return count;
        }

        public Node LastNode()
        {
            Node temp = Head;
            while (temp.Next != null)
                temp = temp.Next;
            return temp;
        }

        public void Reverse()
        {
            Node prev = null;
            Node Current = Head;
            while(Head.Next != null )
            {
                Node next = Current.Next;
                prev = Current;
                Current = next;
            }
        }

        public void InsertBefore(Node n, int pos)
        {
            Node node = Head;
            int i = 0;
            while(node != null && i < pos)
            {
                node = node.Next;
                i++;
            }

            
        }

    }

    public class CircularLinkList
    {
        public Node Tail = null;

        public void AddNode(Node n)
        {
            if(Tail == null)
            {
                Tail = n;
                Tail.Next = Tail;
            }
            else
            {
                Node tempNode = Tail.Next;
                Tail.Next = n;
                n.Next = tempNode;
                Tail = n;
            }
            
        }

        public void Traverse()
        {
            Node current = Tail.Next;
            
            while (current != Tail)
            {
                Console.WriteLine(current.Value);
                current = current.Next;
                
            }
            Console.WriteLine(current.Value);
        }
    }

    public class MultiList
    {
        Node Head;
        Node CurrentHead;

        public void AddNode(Node node)
        {
            if(Head == null)
            {
                CurrentHead = Head = node;
            }
            else
            {
                GetLastNode().Next = node;
            }
        }

        public void AddList(Node node)
        {
            if(Head == null)
            {
                CurrentHead = Head = node;
            }
            else
            {
                CurrentHead.Right = node;
                CurrentHead = node;
            }
        }

        private Node GetLastNode()
        {
            Node temp = CurrentHead;
            while (temp.Next != null)
                temp = temp.Next;
            return temp;
        }

        public void Traverse()
        {
            Node localHead = Head;
            Node current = Head;

            while (localHead.Right != null || current.Next != null)
            { 
                Console.WriteLine(current.Value);
                if (current.Next == null)
                {
                    localHead = localHead.Right;
                    current = localHead;
                }
                else
                    current = current.Next;
            }

            Console.WriteLine(current.Value);
        }
    }
}
