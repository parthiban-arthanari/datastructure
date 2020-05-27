using System;
namespace Sample.Heap
{
    public class Heap
    {
        int _heap_type;
        int _capacity;
        int _count;
        int[] _arr;

        public int Count
        {
            get { return this._count; }
            set { this._count = value; }
        }
        

        public Heap(int capacity, int heap_type)
        {
            this._heap_type = heap_type;
            this._capacity = capacity;
            this._count = 0;
            this._arr = new int[_capacity];
        }

        public int Parent(int i)
        {
            if (i <= 0 || i >= this._count)
                return -1;
            return (i - 1) / 2;
        }

        public int LeftChild(int i)
        {
            int left = 2 * i + 1;

            if (left >= this._count)
                return -1;

            return left;
        }

        public int RightChild(int i)
        {
            int right = 2 * i + 2;

            if (right >= this._count)
                return -1;

            return right;
        }

        public int GetMaxOrMin()
        {
            if (this._count == 0)
                return -1;

            return this._arr[0];
        }

        public void PercolateDown(int i)
        {
            int l, r, minMax, temp;

            l = LeftChild(i);
            r = RightChild(i);

            if (this._heap_type == 1)
            {
                if (l != -1 && this._arr[l] > this._arr[i])
                    minMax = l;
                else
                    minMax = i;

                if (r != -1 && this._arr[r] > this._arr[minMax])
                    minMax = r;
            }
            else
            {
                if (l != -1 && this._arr[l] < this._arr[i])
                    minMax = l;
                else
                    minMax = i;

                if (r != -1 && this._arr[r] < this._arr[minMax])
                    minMax = r;
            }

            if (minMax != i)
            {
                temp = this._arr[i];
                this._arr[i] = this._arr[minMax];
                this._arr[minMax] = temp;

                PercolateDown(minMax);
            }
        }
        
        public int Delete(int i = 0)
        {
            int data;
            if (this._count == 0)
                throw new IndexOutOfRangeException("Heap is empty");

            data = _arr[i];
            _arr[i] = _arr[0];
            _arr[0] = _arr[_count - 1];
            _count--;

            PercolateDown(i);

            return data;
        }

        public void PercolateUp(int i)
        {
            if (i <= 0 || i >= this._count)
                return;

            int parent = (i - 1) / 2;

            if (this._heap_type == 1)
            {
                if (this._arr[i] > this._arr[parent])
                {
                    int temp = this._arr[i];
                    this._arr[i] = this._arr[parent];
                    this._arr[parent] = temp;
                    PercolateUp(parent);
                }
            }
            else
            {
                if (this._arr[i] < this._arr[parent])
                {
                    int temp = this._arr[i];
                    this._arr[i] = this._arr[parent];
                    this._arr[parent] = temp;
                    PercolateUp(parent);
                }
            }
        }

        public int Insert(int data)
        {
            if (this._count >= this._capacity)
                return -1;

            this._count++;
            int i = this._count - 1;
            this._arr[i] = data;

            PercolateUp(i);

            return i;
        }

        public void BuildHeap(int[] arr)
        {
            int n = arr.Length;

            if (n > this._capacity)
                return;

            this._arr = new int[n];

            for(int i =0; i<n; i++)
            {
                this._arr[i] = arr[i];
            }

            this._count = n;

            for(int i = (this._count-2)/2;i>=0; i--)
            {
                PercolateDown(i);
            }
        }
    }
}
