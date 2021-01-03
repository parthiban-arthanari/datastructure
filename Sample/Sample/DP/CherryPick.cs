using System;

namespace Sample.DP
{
    public class CherryPick
    {
        public static CherryPick Instance = new CherryPick();
        int[][] grid;
        int[][][] memo;

        private void Read()
        {
            grid = Utility.Convert2DArray<int>("[[0,1,-1],[1,0,-1],[1,1,1]]", 3);
        }

        public void Do()
        {
            Read();
            // int val = MaxPick(grid);
            int val = CherryPickByDP(grid);
        }

        private int MaxPick(int[][] grid)
        {
            int ans = 0;
            int[][] path = BestPath(grid);
            if(path == null)
                return 0;
            foreach(int[] p in path)
            {
                ans += grid[p[0]][p[1]];
                grid[p[0]][p[1]] = 0;
            }

            path = BestPath(grid);
            foreach(int[] p in path)
            {
                ans += grid[p[0]][p[1]];
            }

            return ans;

        }

        private int[][] BestPath(int[][] gird)
        {
            int n = grid.Length;
            int[][] dp = new int[n][];

            for(int i=0; i<n; i++)
            {
                dp[i] = new int[n];
                System.Array.Fill(dp[i], int.MinValue);
            }

            dp[n-1][n-1] = grid[n-1][n-1];

            for(int i=n-1; i>=0; i--)
            {
                for(int j=n-1; j>=0; j--)
                {
                    if((i!=n-1 || j!=n-1) && grid[i][j] >= 0)
                    {
                        dp[i][j] = Math.Max(i+1 < n ? dp[i+1][j] : int.MinValue,
                                    j+1 <n ? dp[i][j+1] : int.MinValue);
                        dp[i][j] += grid[i][j];
                    }
                }
            }
            if(dp[0][0] < 0) return null;

            int[][] path = new int[2*n-1][];

            for(int i=0; i<2*n-1; i++)
            {
                path[i] = new int[2];
            }
            
            int i1=0;
            int j1=0;
            int t=0;

            while(i1!=n-1||j1!=n-1)
            {
                if(j1+1 == n || i1+1 < n && dp[i1+1][j1] >= dp[i1][j1+1])
                    i1++;
                else
                    j1++;

                path[t][0] = i1;
                path[t][1] = j1;
                t++;
            }

            return path;
        }

        private int CherryPickByDP(int[][] grid)
        {
            int n = grid.Length;
            memo = new int[n][][];

            for(int i=0; i<n; i++)
            {
                memo[i] = new int[n][];
                for(int j=0; j<n; j++)
                {
                    memo[i][j] = new int[n];
                    System.Array.Fill(memo[i][j], int.MinValue);
                }
            }
            return DP_TopDown(0,0,0,grid);
        }

        private int DP_TopDown(int r1, int c1, int c2, int[][] grid)
        {
            int n = grid.Length;
            int r2 = r1+c1-c2;

            if(r1==n || c1==n || r2==n || c2==n || grid[r1][c1] == -1 || grid[r2][c2] == -1)
                return int.MinValue;
            else if(r1 == n-1 && c1 == n-1)
                return grid[r1][c1];
            else if(memo[r1][c1][c2] != int.MinValue)
                return memo[r1][c1][c2];
            else
            {
                int ans = grid[r1][c1];
                if(c1 != c2)
                    ans += grid[r2][c2];
                ans += Math.Max(
                            Math.Max(DP_TopDown(r1+1, c1, c2, grid), DP_TopDown(r1, c1+1, c2, grid)), 
                            Math.Max(DP_TopDown(r1+1, c1, c2+1, grid), DP_TopDown(r1, c1+1, c2+1, grid)));
                memo[r1][c1][c2] = ans;
                return ans;
            }
        }
    }
}