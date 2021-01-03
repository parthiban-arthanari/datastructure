using System;
using System.Collections.Generic;

namespace Sample.Stack
{
    public class Histogram
    {
        public static Histogram Instance = new Histogram();
        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[2,1,5,6,2,3]");
        }

        public void Do()
        {
            Read();
            var val = MaxHeight(arr);
        }

        private int MaxHeight(int[] arr)
        {
            int n = arr.Length;
            Stack<int> st = new Stack<int>();
            int maxArea = 0;
            st.Push(-1);
            for(int i=0; i<n; i++)
            {
                while(st.Peek()!=-1 && arr[st.Peek()] >= arr[i])
                {
                    maxArea = Math.Max(maxArea, arr[st.Pop()] * (i-st.Peek()-1));
                }
                st.Push(i);
            }

            while(st.Peek() != -1)
            {
                maxArea = Math.Max(maxArea, arr[st.Pop()] * (n-st.Peek()-1));
            }

            return maxArea;
        }
    }
}