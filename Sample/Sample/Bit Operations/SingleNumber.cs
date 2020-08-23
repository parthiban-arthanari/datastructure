using System;
namespace Sample.Bit
{
    public class SingleNumber
    {
        public static SingleNumber Instance = new SingleNumber();
        int[] array;

        private void Read()
        {
            Console.WriteLine("Enter Number with Comma Separated");
            array = new int[] { 1,2,1,3,2,5 };
        }

        public void Do()
        {
            Read();
            // var val = FindSingleNumber(array);
            // var val = FindSingleNumber2(array);
            var val = FindSingleNumber2(array);
        }

        private int FindSingleNumber(int[] nums)
        {
            int singleNum = 0;
            for(int i=0; i<nums.Length; i++)
            {
                singleNum = singleNum ^ nums[i];
            }

            return singleNum;
        }

        private int FindSingleNumber2(int[] nums)
        {
            int once = 0, twice = 0, val, not, temp;
            int ret = 0;
            for(int i=0; i<nums.Length; i++)
            {
                val = nums[i];
                ret = ret ^ val;
                not = ~twice;
                temp = (once ^ val);
                once = not & temp;
                not = ~once;
                temp = (twice ^ val);
                twice = not & temp;
            }

            return twice;
        }

        private int[] FindSingleNumber3(int[] nums)
        {
            int bitmask = 0; 
            for (int i =0; i<nums.Length; i++) bitmask ^= nums[i];

            int diff = bitmask & (-bitmask);

            int x = 0;
            for (int i=0; i<nums.Length; i++) 
            {
                if ((nums[i] & diff) != 0) 
                {
                    x ^= nums[i];
                }
            }

            return new int[]{x, bitmask^x};
        }
    }
}
