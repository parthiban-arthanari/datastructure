using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class NextGreater
    {
        public static NextGreater Instance = new NextGreater();

        int num;

        private void Read()
        {
            num = 1642;
        }

        public void Do()
        {
            Read();
            var val = GetSmallest(num);
        }

        private int GetSmallest(int num)
        {
           char[] arr= num.ToString().ToCharArray();

           int i = arr.Length - 2;
            while(i>=0 && arr[i+1] <= arr[i])
                i--;
           
           int j = arr.Length -1;
            while(j<=0 && arr[j] <= arr[i])
                j--;
            
            Swap(arr, i, j);
            Reverse(arr, i+1, arr.Length -1);
            int n = -1;
            Int32.TryParse(arr, out n);
            
            return n;
        }

        private void Swap(char[] a, int i, int j)
        {
            char temp = a[i];
            a[i] = a[j];
            a[j] = temp;
        }

        private void Reverse(char[] a, int start, int end)
        {
            while(start <= end)
            {
                Swap(a, start, end);
                start++;
                end--;
            }
        }
    }
}