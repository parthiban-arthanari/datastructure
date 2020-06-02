using System;
namespace Sample.Heap
{
    public class Heap<T>  where T : IComparable<T>
    {
        int _heap_type;
        int _capacity;
        int _count;
        T[] _arr;

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
            this._arr = new T[_capacity];
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

        public T GetMaxOrMin()
        {
            if (this._count == 0)
                throw new InvalidOperationException("There are no elements in the heap");

            return this._arr[0];
        }

        public void PercolateDown(int i)
        {
            int l, r, minMax;
            T temp;

            l = LeftChild(i);
            r = RightChild(i);

            if (this._heap_type == 1)
            {
                if (l != -1 &&  this._arr[l].CompareTo(this._arr[i]) > 0)
                    minMax = l;
                else
                    minMax = i;

                if (r != -1 && this._arr[r].CompareTo(this._arr[minMax]) > 0)
                    minMax = r;
            }
            else
            {
                if (l != -1 && this._arr[i].CompareTo(this._arr[l]) > 0)
                    minMax = l;
                else
                    minMax = i;

                if (r != -1 && this._arr[minMax].CompareTo(this._arr[r]) > 0)
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
        
        public T Delete(int i = 0)
        {
            T data;
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
                if (this._arr[i].CompareTo(this._arr[parent]) > 0)
                {
                    T temp = this._arr[i];
                    this._arr[i] = this._arr[parent];
                    this._arr[parent] = temp;
                    PercolateUp(parent);
                }
            }
            else
            {
                if (this._arr[i].CompareTo(this._arr[parent]) < 0)
                {
                    T temp = this._arr[i];
                    this._arr[i] = this._arr[parent];
                    this._arr[parent] = temp;
                    PercolateUp(parent);
                }
            }
        }

        public int Insert(T data)
        {
            if (this._count >= this._capacity)
                return -1;

            this._count++;
            int i = this._count - 1;
            this._arr[i] = data;

            PercolateUp(i);

            return i;
        }

        public void BuildHeap(T[] arr)
        {
            int n = arr.Length;

            if (n > this._capacity)
                return;

            this._arr = new T[n];

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
