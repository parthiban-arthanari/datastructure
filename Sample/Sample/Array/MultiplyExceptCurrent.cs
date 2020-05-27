using System;
namespace Sample.Array
{
    public class MultiplyExceptCurrent
    {
        public static MultiplyExceptCurrent Instance = new MultiplyExceptCurrent();
        int[] arr;
        public MultiplyExceptCurrent()
        {
            arr = new[] { 2,2,3,1,4,5 ,2};
        }

        public void Do()
        {
            Mul(arr);
        }

        private void Mul(int[] arr)
        {
            int[] leftMultiply = new int[arr.Length];
            int value = 1;

            for(int i=0; i<arr.Length; i++)
            {
                leftMultiply[i] = value;
                value = value * arr[i];
            }

            value = 1;
            for(int i=arr.Length -1; i>=0; i--)
            {
                int temp = arr[i];
                arr[i] = leftMultiply[i] * value;
                value = value * temp;
            }
        }
    }
}
