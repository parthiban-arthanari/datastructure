using System;

namespace Sample.BackTracking
{
    public class CherryPick
    {
        public static CherryPick Instance = new CherryPick();

        int[][] grid;
        int Total = 0;
        int[] Moves = {-1,0,1};
        int ROW;
        int COL;

        private void Read()
        {
            //grid = Utility.Convert2DArray<int>("[[1,0,0,0,0,0,1],[2,0,0,0,0,3,0],[2,0,9,0,0,0,0],[0,3,0,5,4,0,0],[1,0,2,3,0,0,6]]", 4);
            grid = new int[5][];
            grid[0] = new[] {1,0,0,0,0,0,1};
            grid[1] = new[] {2,0,0,0,0,3,0};
            grid[2] = new[] {2,0,9,0,0,0,0};
            grid[3] = new[] {0,3,0,5,4,0,0};
            grid[4] = new[] {1,0,2,3,0,0,6};
        }

        public void Do()
        {
            Read();
            var val = MaxPick(grid);
        }

        private int MaxPick(int[][] grid)
        {
            ROW = grid.Length;
            if(ROW > 0)
            COL = grid[0].Length;
            else return 0;
            int max = MaxPick1(grid, 0);
            return Math.Max(max, MaxPick1(grid, COL-1));
        }

        private int MaxPick1(int[][] grid, int c)
        {
            bool[,] mat = new bool[ROW,COL];
            bool traversed = false;

            Pick(grid, 0, (COL+c)%COL, grid[0][0], mat, traversed);
            int temp = Total;
            Total = 0;
            traversed = true;

            Pick(grid, 0, (COL-1-c)%COL, 0, mat, traversed);
            return Total + temp;
        }

        private void Pick(int[][] grid, int r, int c, int cherry, bool[,] mat, bool traversed)
        {
            if(r == ROW -1)
                Total = Math.Max(Total, cherry);
            else
            {
                for(int i=0; i<3; i++)
                {
                    int r1 = r + 1;
                    int c1 = c + Moves[i];
                    if(c1 >= 0 && c1 <COL)
                    {
                        int ch = mat[r1,c1] && traversed ? 0 : grid[r1][c1];
                        Pick(grid, r1,c1, cherry+ch, mat, traversed);
                        mat[r1,c1] = true;
                    }
                }
            }
        }
    }
}


class Solution {
    public int cherryPickup(int[][] grid) {
        int m = grid.Length;
        int n = grid[0].Length;
        int[,,] dpCache = new int[m,n,n];
        // initial all elements to -1 to mark unseen
        for (int i = 0; i < m; i++) {
            for (int j = 0; j < n; j++) {
                for (int k = 0; k < n; k++) {
                    dpCache[i,j,k] = -1;
                }
            }
        }
        return dp(0, 0, n - 1, grid, dpCache);
    }

    private int dp(int row, int col1, int col2, int[][] grid, int[,,] dpCache) {
        if (col1 < 0 || col1 >= grid[0].Length || col2 < 0 || col2 >= grid[0].Length) {
            return 0;
        }
        // check cache
        if (dpCache[row,col1,col2] != -1) {
            return dpCache[row,col1,col2];
        }
        // current cell
        int result = 0;
        result += grid[row][col1];
        if (col1 != col2) {
            result += grid[row][col2];
        }
        // transition
        if (row != grid.Length - 1) {
            int max = 0;
            for (int newCol1 = col1 - 1; newCol1 <= col1 + 1; newCol1++) {
                for (int newCol2 = col2 - 1; newCol2 <= col2 + 1; newCol2++) {
                    max = Math.Max(max, dp(row + 1, newCol1, newCol2, grid, dpCache));
                }
            }
            result += max;
        }

        dpCache[row,col1,col2] = result;
        return result;
    }
}