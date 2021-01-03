using System;

namespace Sample.Array
{
    public class IncreasingTriplet
    {
        public static IncreasingTriplet Instance = new IncreasingTriplet();
        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[2,1,5,0,4,6]");
        }

        public void Do()
        {
            Read();
            var val = IsIncreasing(arr);
        }

        private bool IsIncreasing(int[] arr)
        {
            int first = int.MaxValue;
            int second = int.MaxValue;

            foreach(int n in arr)
            {
                if(n <= first)
                    first = n;
                else if(n<= second)
                    second = n;
                else
                 return true;
            }
            return false;
        }
    }
}