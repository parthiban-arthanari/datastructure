using System;
using System.Linq;

namespace Sample.Array
{
    public class FindLengthOfSum
    {
        public static FindLengthOfSum Instance = new FindLengthOfSum();
        public void Do()
        {
            Console.WriteLine("Enter array of numbers in string");
            string s = Console.ReadLine();

            int[] values = s.Select(item => int.Parse(item.ToString())).ToArray();

            Console.WriteLine("Enter the Sum length to find");
            int maxSum = int.Parse(Console.ReadLine());

            int length = -1;
            int sum = 0;
            int start = 0;

            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];

                while (sum >= maxSum)
                {
                    int tempLength = i - start + 1;
                    if (length == -1 || length > tempLength)
                    {
                        length = tempLength;
                    }

                    sum -= values[start];
                    start++;
                }

            }

            Console.WriteLine("Min length of sum is:" + length);
        }
    }
}
