using System;

namespace Sample.Array
{
    public class FindDuplicate
    {
        public static FindDuplicate Instance = new FindDuplicate();

        int[] nums;

        private void Read()
        {
            nums = Utility.ConvertArray<int>("[1,3,4,2,2]");
        }

        public void Do()
        {
            Read();
            int val = Find(nums);
        }

        private int Find(int[] nums)
        {
            int p1 = nums[0];
            int p2 = p1;

            do
            {
                p1 = nums[p1];
                p2 = nums[nums[p2]];
            }while(p1 != p2);

            p1= nums[0];

            while(p1!=p2)
            {
                p1 = nums[p1];
                p2 = nums[p2];
            }

            return p1;
        }
    }
}