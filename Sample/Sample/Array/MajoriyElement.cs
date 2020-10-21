using System;
using Sample.Algorithm;
using System.Collections.Generic;

namespace Sample.Array
{
    public class MajorityElement
    {
        public static MajorityElement Instance = new MajorityElement();
        private int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[3,2,3]");
        }
        public void Do()
        {
            Read();
            var val = FindMajority_n3(arr);
        }

        private int FindElement(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int value = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                    map[nums[i]]++;
                else
                    map[nums[i]] = 1;
            }

            foreach (var item in map)
            {
                if (item.Value >= nums.Length / 2 && item.Value > value)
                    value = item.Key;
            }

            return value;
        }

        private int FindMajority(int[] nums)
        {
            return BoyerMoore_Voting.Instance.FindMajority(nums);
        }

        private IList<int> FindMajority_n3(int[] nums)
        {
            return BoyerMoore_Voting.Instance.FindMajority_n3(nums);
        }
    }
}
