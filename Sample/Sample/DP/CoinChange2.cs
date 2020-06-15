using System;

namespace Sample.DP
{
    public class CoinChange2
    {
        public static CoinChange2 Instance = new CoinChange2();

        int _amount;
        int [] _coins;

        private void Read()
        {
            _amount = 5;
            _coins = Utility.ConvertArray<int>("[1, 2, 5]");
        }

        public void Do()
        {
            Read();
            Change(_amount, _coins);
        }

        private int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];

            dp[0] = 1;

            for(int i=0; i<coins.Length; i++)
            {
                for(int j = coins[i]; j <=amount; j++)
                {
                    dp[j] += dp[j- coins[i]];
                }
            }

            return dp[amount];
        }
        
    }
}