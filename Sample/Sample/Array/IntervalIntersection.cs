using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class IntervalIntersection
    {
        public static IntervalIntersection Instance = new IntervalIntersection();
        int[][] a;
        int[][] b;

        public void Read()
        {
            // a = new int[4][];
            // a[0] = new int[]{0,2};
            // a[1] = new int[]{5,10};
            // a[2] = new int[]{13,23};
            // a[3] = new int[]{24,25};

            // b = new int[4][];
            // b[0] = new int[]{1,5};
            // b[1] = new int[]{8,12};
            // b[2] = new int[]{15,24};
            // b[3] = new int[]{25,26};

            a = new int[2][];
            a[0] = new int[]{3,5};
            a[1] = new int[]{9,20};
            

            b = new int[5][];
            b[0] = new int[]{4,5};
            b[1] = new int[]{7,10};
            b[2] = new int[]{11,12};
            b[3] = new int[]{14,15};
            b[4] = new int[]{16,20};
        }

        public void Do()
        {
            Read();
            Find(a,b);
        }

        private int[][] Find(int[][] A, int[][] B)
        {
            List<int[]> list = new List<int[]>();

            int i = 0, j=0;

            while(i<A.Length && j<B.Length)
            {
                int i1 = Math.Max(A[i][0], B[j][0]);
                int i2 = Math.Min(A[i][1], B[j][1]);

                if(i1<=i2)
                    list.Add(new int[]{i1,i2});
                
                if(A[i][1] < B[j][1])
                    i++;
                else
                    j++;
            }

            return list.ToArray();
        }

        private bool FindIntersection(int[][] arr, Stack<int[]> stack, int index)
        {
            if(index < arr.Length)
            {
                if(stack.Count > 0)
                {
                    var r1 = stack.Pop();
                    var r2 = arr[index];

                    int i1 = Math.Max(r1[0], r2[0]);
                    int i2 = Math.Min(r1[1], r2[1]);

                    if(i1 <= i2)
                    {
                        stack.Push(new int[]{i1, i2});
                    }
                    if(r1[1] > i2)
                    {
                        stack.Push(r1);
                        return  true;
                    }
                    else
                    {
                        stack.Push(r2);
                    }
                }
                else
                {
                stack.Push(arr[index]);
                }
            }

             return false;
        }
    }
}