using System;
using System.Collections.Generic;

namespace Sample.Algorithm
{
    public class BoyerMoore_Voting
    {
        public static BoyerMoore_Voting Instance = new BoyerMoore_Voting();

        int[] _arr;

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("");
        }

        public void Do()
        {
            Read();
            var val = FindMajority_n3(_arr);
        }

        public int FindMajority(int[] nums)
        {
            int candidate = 0;
            int count = 0;

            foreach(int i in nums)
            {
                if(count == 0)
                    candidate = i;

                count += candidate == i ? 1 : -1;
            }

            return candidate;
        }

        public List<int> FindMajority_n3(int[] nums)
        {
            int count1 =0, count2 = 0;
            int? candidate1 = null, candidate2 = null;

            foreach(var num in nums)
            {
                if(candidate1 != null && candidate1 == num)
                    count1++;
                else if(candidate2 != null && candidate2 == num)
                    count2++;
                else if(count1 == 0)
                {
                    candidate1 = num; 
                    count1++;
                }
                else if(count2 == 0)
                {
                    candidate2 = num;
                    count2++;
                }
                else
                {
                    count1--;
                    count2--;
                }
            }

            List<int> result = new List<int>();
            count1 = 0;
            count2 = 0;
            foreach(var num in nums)
            {
                if(candidate1 != null && candidate1 == num)
                    count1++;
                if(candidate2 != null && candidate2 == num)
                    count2++;
            }

            int n = nums.Length;

             if(count1 > n/3) result.Add(count1);
            if(count2 > n/3) result.Add(count2);

            return result;
        }
    }
}