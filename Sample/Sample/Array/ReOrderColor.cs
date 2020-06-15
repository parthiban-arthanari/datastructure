using System;

namespace Sample.Array
{
    public class ReOrderColor
    {
        public static ReOrderColor Instance = new ReOrderColor();
        int[] _arr;

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("[2,0,2,1,1,0]");
        }

        public void Do()
        {
            Read();
            Sort(_arr);
        }

        private void Sort(int[] nums)
        {
            int zero = 0;
            int two = nums.Length - 1;
            int pointer = 0;
            int temp;

                while(pointer <= two)
                {
                    int val = nums[pointer];
                    if(val == 0)
                    {   
                        temp = nums[zero];
                        nums[zero++] = val;
                        nums[pointer++] = temp;
                    }
                    else if(nums[pointer] == 2)
                    {
                        temp = nums[two];
                        nums[two--] = val;
                        nums[pointer] = temp;
                    }
                    else 
                    {
                        pointer++;
                    }
                }
        }
    }
}