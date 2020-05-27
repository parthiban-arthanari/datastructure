using System;
using System.Collections.Generic;
using Sample.Helper;
namespace Sample.DayChallenge
{
    public class NumerOfOnesZeros
    {
        public static NumerOfOnesZeros Instance = new NumerOfOnesZeros();
        int[] array;

        private void Read()
        {
            array = new int[] { 1, 0, 0, 1, 0, 0, 1, 1 };
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Maximun Number of 0's and 1's - {0}", CountNumbers(array));
        }

        private int CountNumbers(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, -1);
            int maxlen = 0, count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                count = count + (nums[i] == 0 ? -1 : 1);
                if (dict.ContainsKey(count))
                {
                    maxlen = Math.Max(maxlen, i - dict[count]);
                }
                else
                {
                    dict[count] = i;
                }

            }
            return maxlen;
        }
        
    }
}
