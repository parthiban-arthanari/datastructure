using System;

namespace Sample.DP
{
    public class LCS
    {
        public static LCS Instance = new LCS();

        string w1;
        string w2;

        private void Read()
        {
            w1 = "abc";
            w2 = "aghbedc";
        }

        public void Do()
        {
            Read();
            IsSubSequence(w1, w2);
        }

        private bool IsSubSequence(string s, string t)
        {
            int[,] dp = new int[s.Length +1, t.Length +1];

            for(int i=0; i<=s.Length; i++)
            {
                for(int j=0; j<=t.Length; j++)
                {
                    if(i==0 || j==0)
                    {
                        dp[i,j] = 0;
                    }
                    else if(s[i-1] == t[j-1])
                    {
                        dp[i,j] = 1 +dp[i-1,j-1];
                    }
                    else
                    {
                        dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                    }
                }
            }

            return dp[s.Length,t.Length] == s.Length;
        }
    }
}