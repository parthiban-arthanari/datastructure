using System;
namespace Sample.Array
{
    public class FindLenthOfOneFlippingMZero
    {
        public static FindLenthOfOneFlippingMZero Instance = new FindLenthOfOneFlippingMZero();
        int[] arr;
        int m;

        public FindLenthOfOneFlippingMZero()
        {
            
        }

        private void ReadInputs()
        {
            arr = new[] { 0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1 };
            m = 1;
        }

        public void Do()
        {
            ReadInputs();
            int s = -1;
            int e = -1;
            int count = 0;
            int n = arr.Length;
            int max = -1;

            while (e<n)
            {
                if(count <= m)
                {
                    if(arr[e] == 0)
                    {
                        count++;
                    }
                    e++;
                }
                else
                {
                    if(arr[s] == 0)
                    {
                        count--;
                    }
                    s++;
                }
            }

            if(max < e-s-1)
            {
                max = e - s - 1;
            }

        }
    }
}
