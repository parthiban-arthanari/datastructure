using System;

namespace Sample.DP
{
    public class LeastPerfectSquare
    {
        public static LeastPerfectSquare Instance = new LeastPerfectSquare();
        int num;

        private void Read()
        {
            num = 12;
        }

        public void Do()
        {
            Read();
            int val = NumSquares(num);
        }

        private int NumSquares(int n)
        {
            int[] dp = new int[n+1];
            int s = 1;
            System.Array.Fill(dp, int.MaxValue);
            dp[0] = 0;
            
            while(n >= s*s)
            {
                int square = s*s;
                for(int i=1; i<=n; i++)
                {
                    if(i >= square)
                    {
                        dp[i] = Math.Min(dp[i] , 1 + dp[i- square]);
                    }
                }
                s++;
            }

            return dp[n];
        }
    }
    
}