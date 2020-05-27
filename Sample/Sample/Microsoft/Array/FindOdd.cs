using System;

namespace Sample.Microsoft.Array
{
    public class FindOdd
    {
        public static FindOdd Instance = new FindOdd();

        int[] _arr;

        private void Read()
        {
            _arr = new int[]{1,1,3,3,4,4,5,6,6};
        }

        public void Do()
        {
            Read();
            Find(_arr);
        }

        private int Find(int[] nums)
        {
            int start = 0;
            int end = nums.Length - 1;
            int mid;

            while(start < end)
            {
                mid = (end - start) / 2;

                int index = start + mid;
                if((mid + 1) % 2 == 0)
                {
                    if(nums[index] == nums[index-1])
                        start = index+1;
                    else
                        end = index;
                }
                else
                {
                    if(nums[index] == nums[index+1])
                        start = index;
                    else
                        end = index;
                }
            }

            return nums[start];
            
        }
    }
}