using System;
namespace Sample.DayChallenge
{
    public class StoneSmash
    {
        public static StoneSmash Instance = new StoneSmash();
        int[] _stones;

        private void Read()
        {
            //_stones = new int[] { 2, 7, 4, 1, 8, 1 };
            _stones = new int[] { 2, 2};
        }

       public void Do()
        {
            Read();
            Console.WriteLine("The last stone stands - {0}", FindLastStoneStands(_stones));
        }

        private int FindLastStoneStands(int[] _stones)
        {
            Heap heap = new Heap(_stones.Length, 1);
            heap.BuildHeap(_stones);

            int s1 = 0, s2;
            while(!heap.IsEmpty())
            {   
                s1 = heap.Delete();

                if (heap.IsEmpty())
                    break;

                s2 = heap.Delete();
                int diff;

                if (s1 > s2)
                    diff = s1 - s2;
                else
                    diff = s2 - s1;

                heap.Insert(diff);
            }

            return s1;
        }

        public class Heap
        {
            int[] _arr;
            int _capacity;
            int _count;
            int _heapType;

            public Heap(int capacity, int type)
            {
                _arr = new int[capacity];
                _capacity = capacity;
                _heapType = type;
            }

            public bool IsEmpty()
            {
                return _count == 0;
            }

            private int Parent(int i)
            {
                if (i <= 0 || i >= this._count)
                    return -1;
                return (i - 1) / 2;
            }

            private int LeftChild(int i)
            {
                int left = 2 * i + 1;
                if (left >= this._count)
                    return -1;
                return left;
            }

            private int RightChild(int i)
            {
                int right = 2 * i + 2;
                if (right >= this._count)
                    return -1;
                return right;
            }

            public int GetMinMax()
            {
                if (_count == 0)
                    throw new IndexOutOfRangeException("Heap is empty");
                return _arr[0];
            }

            private void PercolateDown(int i)
            {
                int l, r, minmax, temp;

                l = LeftChild(i);
                r = RightChild(i);

                if(_heapType == 0)
                {
                    if (l != -1 && _arr[l] < _arr[i])
                        minmax = l;
                    else minmax = i;
                    if (r != -1 && _arr[r] < _arr[minmax])
                        minmax = r;
                    if(minmax != i)
                    {
                        temp = _arr[i];
                        _arr[i] = _arr[minmax];
                        _arr[minmax] = temp;
                        PercolateDown(minmax);
                    }
                }
                else
                {
                    if (l != -1 && _arr[l] > _arr[i])
                        minmax = l;
                    else minmax = i;
                    if (r != -1 && _arr[r] > _arr[minmax])
                        minmax = r;
                    if (minmax != i)
                    {
                        temp = _arr[i];
                        _arr[i] = _arr[minmax];
                        _arr[minmax] = temp;
                        PercolateDown(minmax);
                    }
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

            private void PercolateUp(int i)
            {
                if (i <= 0 || i >= _count)
                    return;

                int parent = (i - 1) / 2;
                int temp;

                if(_heapType == 0)
                {
                    if(_arr[i] < _arr[parent])
                    {
                        temp = _arr[i];
                        _arr[i] = _arr[parent];
                        _arr[parent] = temp;
                    }
                }
                else
                {
                    if(_arr[i] > _arr[parent])
                    {
                        temp = _arr[i];
                        _arr[i] = _arr[parent];
                        _arr[parent] = temp;
                    }
                }

                PercolateUp(parent);
            }

            public int Insert(int data)
            {
                if (_count >= _capacity)
                    return -1;

                int i = _count++;

                _arr[i] = data;
                PercolateUp(i);
                return i;
            }

            public int BuildHeap(int[] arr)
            {
                int n = arr.Length;

                if (n > _capacity)
                    return -1;

                _arr = arr;
                _count = _arr.Length;
                for(int i = ((_count -1)-1)/2; i>=0; i--)
                {
                    PercolateDown(i);
                }

                return 0;
            }
        }
    }
}
