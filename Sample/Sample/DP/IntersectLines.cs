using System;
using System.Collections.Generic;

namespace Sample.DP
{
    public class IntersectLines
    {
        public static IntersectLines Instance = new IntersectLines();

        int[] _a;
        int[] _b;

        private void Read()
        {
            _a = new int[] {1,1,3,5,3,3,5,5,1,1};
            _b = new int[] {2,3,2,1,3,5,3,2,2,1};
        }

        public void Do()
        {
            Read();
            Console.WriteLine(CountLines(_a, _b));
        }

        private int CountLines(int[] A, int[] B)
        {
            int[][] arr = new int[A.Length +1][];

            for(int i=0; i < A.Length +1; i++)
            {
                arr[i] = new int[B.Length +1];
                for(int j =0; j< B.Length +1; j++)
                {
                    if(i==0 || j==0)
                        arr[i][j] = 0;
                    else if(A[i-1] == B[j-1])
                    {
                        arr[i][j] = Math.Max(arr[i-1][j-1] + 1, Math.Max(arr[i][j-1], arr[i-1][j]));
                    }
                    else
                    {
                        arr[i][j] = Math.Max(arr[i-1][j-1], Math.Max(arr[i][j-1], arr[i-1][j]));
                    }
                }
            }

            return arr[A.Length][B.Length];
        }

        private void Check(int val, int i, Dictionary<int, int> map1, Dictionary<int, int> map2)
        {
           
        }
    }
}