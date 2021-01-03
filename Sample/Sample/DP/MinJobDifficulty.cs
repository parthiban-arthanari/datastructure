using System;
using System.Collections.Generic;
using System.Linq;
using Sample;

namespace Sample.DP
{
    public class MinJobDifficulty
    {
        public static MinJobDifficulty Instance = new MinJobDifficulty();
        int[] _jobs;
        int _days;
        int[,] seg;

        private void Read()
        {
            _jobs = Utility.ConvertArray<int>("[3,2,1]");
            _days = 2;
            int j1 = _days +1;
            int i1 = (_jobs.Length + 1)*4;
            seg = new int[j1,i1];

            for(int j=0; j<j1; j++)
                for(int i=0; i<i1; i++)
                    seg[j,i] = int.MaxValue/2;
        }

        public void Do()
        {
            Read();
            var val = MinDifficulty(_jobs, _days);
        }

        private int MinDifficulty(int[] jd, int d)
        {
            if(jd.Length < d)
                return -1;
            
            int n = jd.Length;
            int[,] dp = new int[n+1,d+1];
            int[] g = new int[n];
            Stack<int> st = new Stack<int>();

            System.Array.Fill(g, n);
            for(int i=0; i<n; i++)
            {
                while(st.Count > 0 && jd[i] > jd[st.Peek()])
                    g[st.Pop()] = i;
                st.Push(i);
            }

            dp[n,d] = 0;
            Update(0,n,0,n,d,0);

            for(int i=0; i<n; i++)
                dp[i,d] = int.MaxValue/2;
            for(int i=0; i<d; i++)
                dp[n,i] = int.MaxValue/2;

            for(int i=n-1; i>=0; i--)
            {
                for(int j=d-1; j>=0; j--)
                {
                    var pre = dp[g[i],j];
                    var currentJob = jd[i];
                    //var minOfPrev = Math.Min(dp[i+1,j+1], dp[g[i], j+1]);
                    var minOfPrev = Get(0,n,0,i+1,g[i], j+1);
                    
                    var temp = Math.Min(pre, currentJob+minOfPrev);
                    dp[i,j] = temp;
                     Update(0,n,0,i,j,temp);
                }
            }

            return dp[0,0];
        }

        private int Get(int l, int r, int i, int L, int R, int j)
        {
            if(l>R || r<L)
                return int.MaxValue/2;
            
            if(l>=L && r<=R)
                return seg[j,i];
            return Math.Min(Get(l, (l+r)/2, i*2+1, L,R, j), Get((l+r)/2+1, r, i*2+2, L,R,j));
        }

        private void Update(int l, int r, int i, int k, int j, int x)
        {
            if(k<l || k>r)
                return;

            if(l==r)
                seg[j,i] = x;
                
            else
            {
                Update(l, (l+r)/2, i*2+1, k,j,x);
                Update((l+r)/2+1, r, i*2+2, k,j,x);
                seg[j,i] = Math.Min(seg[j,i*2+1], seg[j, i*2+2]);
            }
        }

        private int MinDifficulty1(int[] jobDifficulty, int d)
        {
        int n = jobDifficulty.Length;

        if(n < d)
            return -1;
        int[,] dp = new int[n + 1, d + 1];

        for(int i=0; i<n; i++)
            dp[i,d] = int.MaxValue /2;

        for(int i =0; i<d ; i++)
            dp[n,i] = int.MaxValue /2;

        dp[n,d] = 0;
        
        for(int i = n-1; i >= 0; i--)
        {
            for(int j = d-1; j >= 0; j--)
            {
                dp[i,j] = int.MaxValue/2;
                int md = 0;
                for(int k = i; k < n; k++)
                {
                    md = Math.Max(md, jobDifficulty[k]);
                    dp[i,j] = Math.Min(dp[i,j], dp[k+1, j + 1] + md);
                }
            }
        }
        return dp[0,0];
        }

        public int MinDifficulty2(int[] complexity, int days) 
        {
        int len = complexity.Length;
        int[][] dp = new int[days][];

        if (days > len) return -1;

        // base line, for d == 1
        dp[0] = new int[len];
        dp[0][0] = complexity[0];
        for(var i = 1; i < len; i++) {
            var job = complexity[i];
            dp[0][i] = Math.Max(dp[0][i-1], complexity[i]);
        }
        
        // from d == 2 and above
        for (int i = 1; i < days; i++) {
            dp[i] = new int[len];
            for (int j = i; j < len; j++) {
                int minDiff = int.MaxValue;
                int maxForNewDay = 0;
                for (int k = j; k >= i; k--) {
                    maxForNewDay = Math.Max(maxForNewDay, complexity[k]);
                    minDiff = Math.Min(minDiff, dp[i - 1][k - 1] + maxForNewDay);
                }
                dp[i][j] = minDiff;
            }
        }
        return dp.Last().Last();
    }
        
    }
    
}