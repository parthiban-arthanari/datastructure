using System;

namespace Sample.DP
{
    public class HouseRobber
    {
        public static HouseRobber Instance = new HouseRobber();
        int[] _arr;

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("");
        }

        public void Do()
        {
            Read();
        }

        private int GetMaxMoney(int[] arr)
        {
            int prevMax = 0;
            int currMax = 0;
            for(int i=0; i<arr.Length-1; i++)
            {
                int temp = currMax;
                currMax = Math.Max(prevMax + arr[i], currMax);
                prevMax = temp;
            }
            for(int i=1; i<arr.Length; i++)
            {
                int temp = currMax;
                currMax = Math.Max(prevMax + arr[i], currMax);
                prevMax = temp;
            }

            return currMax;
        }
    }
}