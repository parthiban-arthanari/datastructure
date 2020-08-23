using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class FindNDuplicates
    {
        public static FindNDuplicates Instance = new FindNDuplicates();

        int[] _arr;

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("[4,3,2,7,8,2,3,1]");
        }

        public void Do()
        {
            Read();
            var val = Duplicates(_arr);
        }

        private IList<int> Duplicates(int[] nums)
        {
            IList<int> res = new List<int>();

            foreach(var item in nums)
            {
                if(nums[Math.Abs(item) - 1] < 0)
                    res.Add(Math.Abs(item));
                nums[Math.Abs(item) - 1] *= -1;
            }

            return res;
        }
    }
}