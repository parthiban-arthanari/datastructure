using System;
using System.Collections.Generic;

namespace Sample.Microsoft.Array
{
    public class TwoSum
    {
        public static TwoSum Instance = new TwoSum();
        int[] arr;
        int target;

        private void Read()
        {
            arr = new int[]{9,3,5,7,8};
            target = 13;
        }

        public void Do()
        {
            Read();
            int[] val = FindSum(arr, target);
            Console.WriteLine("The number {0}, {1} forms Sum({2})", val[0], val[1], target);
        }

        private int[] FindSum(int[] nums, int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            int Sum = 0;
            for(int i = 0; i<nums.Length; i++)
            {
                Sum = nums[start] + nums[end];

                if(Sum == target)
                    break;

                if(Sum < target)
                {
                    if(nums[start] < nums[end])
                        start++;
                    else
                        end--;
                }
                else
                {
                    if(nums[start] < nums[end])
                        end--;
                    else
                        start++;
                }
            }

            return new int[] {start, end};
        }

        private int[] FindSum1(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for(int i=0 ; i< nums.Length; i++)
            {
                if(map.ContainsKey(target - nums[i]))
                    return new int[] {map[target - nums[i]], i};
                else
                {
                    map[nums[i]] = i;
                }
            }

            return new int[] {0,0};
        }
    }
}