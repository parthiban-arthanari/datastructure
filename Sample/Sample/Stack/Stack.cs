using System;
namespace Sample.Stack
{
    public class Stack
    {
        int[] arr;
        public int top;
        int maxSize;

        public Stack(int maxSize)
        {
            this.maxSize = maxSize;
            this.top = -1;
            this.arr = new int[maxSize];
        }

        public void Push(int data)
        {
            if (!IsFull())
                arr[++top] = data;
            else
                Console.WriteLine("Stack is Full");
        }

        public int Pop()
        {
            if(!IsEmpty())
                return arr[top--];
            Console.WriteLine("Stack is Empty");
            return int.MinValue;
        }

        public int Peek()
        {
            return arr[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }

        public bool IsFull()
        {
            return top == (maxSize - 1);
        }
        
    }

    public class StackList
    {
        SNode Top;

        public void Push(SNode n)
        {
            n.prev = Top;
            Top = n;
        }

        public void Pop()
        {
            SNode temp = Top;
            Top = temp.prev;
        }
    }

    public class SNode
    {
        public SNode prev;
        public int data;

        public SNode(int data)
        {
            this.data = data;
        }
    }
}
