using System;
namespace Sample.Array
{
    public class SingleNumber
    {
        public static SingleNumber Instance = new SingleNumber();
        int[] array;

        private void Read()
        {
            Console.WriteLine("Enter Number with Comma Separated");
            // array = new int[] { 2, 5, 6, 7, 2, 3, 6, 5, 7 };
            array = Utility.ConvertArray<int>("[1,3,4,2,2]");
        }

        public void Do()
        {
            Read();
            // Console.WriteLine("Single Number from given Array {0}", FindSingleNumber(array));
            FindSingleNumber2(array);
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
    }
}
