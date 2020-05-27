using System;
namespace Sample.Queue
{
    public class Queue
    {
        int[] _arr;
        int _maxSize;
        int _front = 0;
        int _rear = -1;

        public Queue(int maxSize)
        {
            this._maxSize = maxSize;
            _arr = new int[maxSize]; 
        }

        public void Enqueue(int data)
        {
            _arr[++_rear] = data;
        }

        public int Dequeue()
        {
           return _arr[_front++];
        }

        public bool IsEmpty()
        {
            //return _rear == -1 || _front == _maxSize;
            return _front > _rear;
        }

        public bool IsFull()
        {
            return _rear == _maxSize - 1;
        }
    }
}
