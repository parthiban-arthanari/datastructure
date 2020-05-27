using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class IntersectLines
    {
        public static IntersectLines Instance = new IntersectLines();

        int[] _a;
        int[] _b;
        int prevIndex = -1;
        int Count = 0;

        private void Read()
        {
            _a = new int[] {1,1,3,5,3,3,5,5,1,1};
            _b = new int[] {2,3,2,1,3,5,3,2,2,1};
        }

        public void Do()
        {
            Read();
            CountLines(_a, _b);
        }

        private void CountLines(int[] A, int[] B)
        {
            int i=0;
            Dictionary<int, int> map1 = new Dictionary<int, int>();
            Dictionary<int, int> map2 = new Dictionary<int, int>();

            if(B.Length > A.Length)
            {
                var temp = A;
                A = B;
                B = temp;
            }
            
            while(i < A.Length && i < B.Length)
            {
                Check(A[i], i, map1, map2);
                Check(B[i], i, map2, map1);
                i++;
            }

            while(i < A.Length)
            {
                Check(A[i], i, map1, map2);
                i++;
            }

        }

        private void Check(int val, int i, Dictionary<int, int> map1, Dictionary<int, int> map2)
        {
            if(map2.ContainsKey(val))
            {
                int index = map2[val];

                if(index > prevIndex)
                {
                    Count++;
                    prevIndex = index;
                    map2.Remove(val);
                }
                else
                {
                    map1[val] = i;
                }
            }
            else
            {
                map1[val] = i;
            }
        }
    }
}