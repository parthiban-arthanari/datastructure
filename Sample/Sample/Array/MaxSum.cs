using System;

namespace Sample.Array
{
    public class MaxSumCircularArray
    {
        public static MaxSumCircularArray Instance = new MaxSumCircularArray();

        int[] arr;

        private void Read()
        {
            arr = new int[] {-2, -3, -1};
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Max Sum - {0}",MaxSum(arr));
        }

        private int MaxSum(int[] A)
        {
            int max_sum = Sum(A);
            int max_warp = 0;

            for(int i =0; i< A.Length; i++)
            {
                max_warp += A[i];
                A[i] = -A[i];
            }

            var temp = max_warp + Sum(A);
            max_warp = temp == 0 ? max_warp : temp;

            return max_warp > max_sum ? max_warp : max_sum;
        }

        private int Sum(int[] arr)
        {
            int max_sum = -int.MaxValue;
            int sum = 0;

            for(int i =0 ; i<arr.Length; i++)
            {
                sum = Math.Max(arr[i], sum + arr[i]);
                max_sum = sum > max_sum ? sum : max_sum;
            }

            return max_sum;
        }
    }
}