using System;

namespace Sample.Array
{
    public class MaxProfit
    {
        public static MaxProfit Instance = new MaxProfit();
        int[] prices;
        
        private void Read()
        {
            prices = Utility.ConvertArray<int>("[7,1,5,3,6,4]");
        }

        public void Do()
        {
            Read();
            var val = FindMax(prices);
        }

        public int FindMax(int[] prices)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            int minIndex = 0;
            int profit = 0;

            for(int i=0; i<prices.Length; i++)
            {
                if(prices[i] < min)
                {
                    min = prices[i];
                    max = int.MinValue;
                    minIndex = i;
                }

                if(prices[i] > max && i > minIndex)
                {
                    max = prices[i];
                    profit = Math.Max(profit, max-min);
                }
            }
            return profit;
        }
    }
}