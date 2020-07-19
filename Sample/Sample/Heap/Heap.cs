using System;
namespace Sample.Heap
{
    public class Heap<T>
    {
        int _heap_type;
        int _capacity;
        int _count;
        T[] _arr;
        Func<T,T,bool> _comparer;

        public int Count
        {
            get { return this._count; }
            set { this._count = value; }
        }
        

        public Heap(int capacity, int heap_type, System.Func<T,T, bool> comparer )
        {
            this._heap_type = heap_type;
            this._capacity = capacity;
            this._count = 0;
            this._arr = new T[_capacity];
            _comparer = comparer;
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

            // if (this._heap_type == 1)
            {
                if (l != -1 && _comparer(_arr[l], _arr[i]))
                    minMax = l;
                else
                    minMax = i;

                if (r != -1 && _comparer(_arr[r], _arr[minMax]))
                    minMax = r;
            }
            // else
            // {
            //     if (l != -1 && _comparer(_arr[i], _arr[l]))
            //         minMax = l;
            //     else
            //         minMax = i;

            //     if (r != -1 && _comparer(_arr[minMax], _arr[r]))
            //         minMax = r;
            // }

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

            // if (this._heap_type == 1)
            {
                if (_comparer(_arr[i], _arr[parent]))
                {
                    T temp = this._arr[i];
                    this._arr[i] = this._arr[parent];
                    this._arr[parent] = temp;
                    PercolateUp(parent);
                }
            }
            // else
            // {
            //     if (_comparer(_arr[i], _arr[parent]))
            //     {
            //         T temp = this._arr[i];
            //         this._arr[i] = this._arr[parent];
            //         this._arr[parent] = temp;
            //         PercolateUp(parent);
            //     }
            // }
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
