using System;
namespace Sample.DayChallenge
{
    public class SingleNumber
    {
        public static SingleNumber Instance = new SingleNumber();
        int[] array;

        private void Read()
        {
            Console.WriteLine("Enter Number with Comma Separated");
            array = new int[] { 2, 5, 6, 7, 2, 3, 6, 5, 7 };
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Single Number from given Array {0}", FindSingleNumber(array));
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
    }
}
