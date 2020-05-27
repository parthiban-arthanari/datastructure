using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Array
{
    public class FindPairOfSum
    {
        public static FindPairOfSum Instance = new FindPairOfSum();

        public void Do()
        {
            Console.WriteLine("Enter array of numbers in string");
            string s = Console.ReadLine();

            int[] values = s.Split(',').Select(item => int.Parse(item.ToString())).ToArray();

            Console.WriteLine("Enter the Sum length to find");
            int maxSum = int.Parse(Console.ReadLine());

            var indices = TwoSum(values, maxSum);

            Console.WriteLine("Indices pair is {0}, {1}", indices[0], indices[1]);


        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int,int> map = new Dictionary<int, int>();
            int remain;

            for(int i=0; i< nums.Length; i++)
            {
                remain = target - nums[i];
                if(!map.ContainsKey(remain))
                {
                    map.Add(nums[i], i);
                }
                else
                {
                    return new[] { i, map[remain] };
                }
            }

            return new int[] { -1, -1};
        }
    }
}
