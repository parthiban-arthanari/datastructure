using System;
using Sample.Heap;
using System.Collections.Generic;

namespace Sample.Greedy
{
    public class CityScheduling
    {
        public static CityScheduling Instance = new CityScheduling();

        int[][] _costs;
        private void Read()
        {
            _costs = Utility.Convert2DArray<int>("[[10,20],[30,200],[400,50],[30,20]]", 2);
        }

        public void Do()
        {
            Read();
            Find(_costs);
        }

        private int Find(int[][] costs)
        {
            System.Array.Sort(costs, new CostComparer());
            
            int total = 0;

            int n = costs.Length /2;

            for(int i=0; i<n; i++) 
            {
                total += costs[i][0] + costs[n+i][1];
            }

            return total;
        }

        public class CostComparer : IComparer<int[]>
        {
            public int Compare(int[] c1, int[] c2)
            {
                return (c1[0] - c1[1] - (c2[0] - c2[1]));
            }
        }

    }
}