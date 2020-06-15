using System;

namespace Sample.DP
{
    public class MinimumOperation
    {
        public static MinimumOperation Instance = new MinimumOperation();

        string s1;
        string s2;

        private void Read()
        {
            s1 = "horse";
            s2 = "ros";
        }

        public void Do()
        {
            Read();
            MinOpr(s1, s2);
        }

        private int MinOpr(string word1, string word2)
        {
            int n = word1.Length + 1;
            int m = word2.Length + 1;
            int[][] dp = new int[n][];

            for(int i=0; i<n; i++)
            {
                dp[i] = new int[m];

                for(int j =0; j<m; j++)
                {
                    if(i==0 || j==0)
                        dp[i][j] = i + j;
                    else
                    {
                        if(word1[i-1] == word2[j-1])
                            dp[i][j] = dp[i-1][j-1];
                        else
                            dp[i][j] = 1 + Math.Min(Math.Min(dp[i-1][j-1], dp[i][j-1]),dp[i-1][j]);
                    }
                }

            }

            return dp[n-1][m-1];
        }
    }
}