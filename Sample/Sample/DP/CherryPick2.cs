using System;

namespace Sample.DP
{
    public class CherryPick2
    {
        public static CherryPick2 Insatance = new CherryPick2();

        int[][] grid;
        int n,m;
        int[][][] dp;

        void Read()
        {
            grid = Utility.Convert2DArray<int>("[[1,0,0,3],[0,0,0,3],[0,0,3,3],[9,0,3,3]]", 4);
            n = grid.Length;
            if(n>0)
                m=grid[0].Length;
        }

        public void Do()
        {
            Read();
            int val = CherryPick(grid);
        }

        private int CherryPick(int[][] grid)
        {
            dp = new int[n][][];

            for(int i=0; i<n; i++)
            {
                dp[i] = new int[m][];
                for(int j=0; j<m; j++)
                {
                    dp[i][j] = new int[m];
                    System.Array.Fill(dp[i][j], -1);
                }
            }

            // return DP_Memoization(0,0,m-1,grid, dp);
            return DP_Tabular(grid, dp);
        }

        int DP_Memoization(int r, int c1, int c2, int[][] grid, int[][][] dp)
        {
            if(c1<0 || c1>=m|| c2<0|| c2>=m)
                return 0;
            else if(dp[r][c1][c2] != -1)
                return dp[r][c1][c2];
            int ans = 0;
            ans += grid[r][c1];
            if(c1!=c2)
                ans += grid[r][c2];

            if(r < n-1)
            {
                int max = 0;
                for(int c11 = c1-1; c11<=c1+1; c11++)
                {
                    for(int c22 = c2-1; c22<=c2+1; c22++)
                    {
                        max = Math.Max(max, DP_Memoization(r+1, c11, c22, grid, dp));
                    }
                }
                ans += max;
            }
            dp[r][c1][c2] = ans;
            return ans;
        }

        int DP_Tabular(int[][] grid, int[][][] dp)
        {
            for(int i=n-1; i>=0; i--)
            {
                for(int j=0; j<m; j++)
                {
                    for(int k=0; k<m; k++)
                    {
                        int ans = 0;
                        ans += grid[i][j];
                        if(j!=k)
                            ans += grid[i][k];
                        
                        if(i < n-1)
                        {
                            int max = 0;
                            for(int c1=j-1; c1<=j+1; c1++)
                            {
                                for(int c2=k-1; c2<=k+1; c2++)
                                {
                                    if(c1>=0 && c1 <m && c2>=0 && c2<m)
                                        max = Math.Max(max, dp[i+1][c1][c2]);
                                }
                            }
                            ans+= max;

                        }
                        dp[i][j][k] = ans;
                    }
                }
            }
            return dp[0][0][m-1];
        }
    }
}