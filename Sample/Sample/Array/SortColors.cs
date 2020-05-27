using System;
namespace Sample.Array
{
    public class SortColors
    {
        public static SortColors Instance = new SortColors();
        int[] nums;

        public SortColors()
        {
        }
        public void Do()
        {
            Read();
            SortColor(nums);

            for(int i=0; i< nums.Length; i++)
            {
                Console.Write(nums[i]+",");
            }
        }

        public void SortColor(int[] nums)
        {
            Sort(nums, 0, nums.Length - 1, 2);
        }

        private void Read()
        {
            nums = new int[] { 2, 0, 1, 0, 1, 2, 0, 1 };
        }

        private void Sort(int[] nums, int start, int end, int max)
        {
            while(start < end)
            {
                if(nums[start] >= max)
                {
                    int temp = nums[end];
                    nums[end] = nums[start];
                    nums[start] = temp;

                    end--;
                    start++;
                }
                else
                {
                    start++;
                }
            }

            if(end != 0)
            {
                Sort(nums, 0, end, max--);
            }

            return;
        }
    }
}
