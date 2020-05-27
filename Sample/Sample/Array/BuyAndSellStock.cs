using System;
namespace Sample.Array
{
    public class BuyAndSellStock
    {
        public static BuyAndSellStock Instance = new BuyAndSellStock();
        int[] prices;

        public BuyAndSellStock()
        {
        }

        public void Do()
        {
            Read();

            Console.WriteLine("Maximum Profit obtained: " + MaxProfit(prices));
            
        }

        private int MaxProfit(int[] prices)
        {
            int profit = 0;
            int min = int.MaxValue;
            int minIndex = 0;
            int max = -int.MaxValue;

            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < min)
                {
                    min = prices[i];
                    max = -int.MaxValue;
                    minIndex = i;
                }

                if (prices[i] > max && i > minIndex)
                {
                    max = prices[i];

                    int diff = max - min;

                    profit = diff > profit ? diff : profit;
                }
            }

            return profit;
        }

        private void Read()
        {
            prices = new int[] { 4, 7, 8, 4, 2, 9 };
        }
    }
}
