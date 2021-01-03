using System;
using System.Collections.Generic;

namespace Sample.DP
{
    public class JumpGame
    {
        public static JumpGame Instance = new JumpGame();

        Dictionary<int, List<int>> dict = new Dictionary<int, List<int>>();
        int[] arr;
        int min = int.MaxValue;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[100,-23,-23,404,100,23,23,23,3,404]");
        }

        public void Do()
        {
            Read();
            int n = arr.Length;
            for(int i=0; i<n; i++)
            {
                if(dict.ContainsKey(arr[i]))
                    dict[arr[i]].Add(i);
                else
                {
                    dict[arr[i]] = new List<int>();
                    dict[arr[i]].Add(i);
                }
            }
            Jump(0, arr, 0);
            var val = min;
        }

        private void Jump(int index, int[] arr, int c)
        {
            int n = arr.Length;
            if(index > n-1 || n < 0)
                return;

            if(index == n-1)
                min = Math.Min(min, c);
            else
            {
                Jump(index+1, arr, c+1);
                Jump(index-1, arr, c+1);
                if(dict.ContainsKey(arr[index]))
                {
                    int len = dict[arr[index]].Count;
                    for(int i=index; i<len; i++)
                        Jump(i, arr, c+1);
                }
            }
        }

    }
}