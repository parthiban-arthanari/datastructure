using System;

namespace Sample.Array
{
    public class SearchInsert
    {
        public static SearchInsert Instance = new SearchInsert();

        int[] arr;
        int num;

        public void Do()
        {
            Read();
            SearchOrInser(arr, num);
        }

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[1,3,6,8,9]");
            num = 7;
        }

        private int SearchOrInser(int[] nums, int target)
        {
            int low = 0;
            int high = nums.Length;

            while(low < high)
            {
                int mid = low + (high - low) / 2;
                if(target < nums[mid])
                    high = mid;
                else if(target > nums[mid])
                    low = mid + 1;
                else
                {
                    low = mid;
                    break;
                }
            }

            return low;
        }
    }
}