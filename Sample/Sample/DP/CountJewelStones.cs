using System;
using System.Collections.Generic;

namespace Sample
{
    public class CountJewelStones
    {
        public static CountJewelStones Instance = new CountJewelStones();
        string J;
        string S;

        private void Read()
        {
            J = "aA";
            S = "aAAbbba";
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Number of Jewel Stones : {0}", JewelStonesCount(J, S));
        }

        private int JewelStonesCount(string jewels, string stones)
        {
            int m = jewels.Length;
            int n = stones.Length;
            int count = 0;

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (jewels[i] == stones[j])
                        count++;
                }
            }
            return count;
        }

        private int JewelStonesCount1(string J, string S)
        {
            int m = J.Length;
            int n = S.Length;
            int count = 0;

            HashSet<char> stonesMap = new HashSet<char>();

            for (int i = 0; i < m; i++)
            {
                stonesMap.Add(J[i]);
            }

            for(int i = 0; i < n; i++)
            {
                if (stonesMap.Contains(S[i]))
                    count++;

            }

            return count;
        }
    }
}
