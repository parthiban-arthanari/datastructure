using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class MissingRange
    {
        public static MissingRange Instance = new MissingRange();
        int[] nums;
        int lower, upper;

        private void Read()
        {
            //nums = Utility.ConvertArray<int>("[-1]");
            //nums = new int[];
            lower = -1;
            upper = -1;
        }

        public void Do()
        {
            Read();
            var val = Find(nums, lower, upper);
        }
        
        private IList<string> Find(int[] nums, int lower, int upper)
        {
            IList<string> list = new List<string>();
            
            for(int i=0; i<nums.Length; i++)
            {
                if(nums[i] > lower)
                {
                    AddRange(lower, nums[i]-1, list);
                    lower = nums[i] +1;
                }
                else
                {
                    lower = nums[i]+1;
                }
            }

            if(lower <= upper)
                AddRange(lower, upper, list);
            return list;
        }

        private void AddRange(int start, int end, IList<string> list)
        {
            if(start == end)
                list.Add(start.ToString());
            else
                list.Add(string.Format("{0}->{1}", start, end));
        }
    }
}