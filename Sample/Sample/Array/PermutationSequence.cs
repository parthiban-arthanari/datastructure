using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Array
{
    public class PermutationSequence
    {
        public static PermutationSequence Instance = new PermutationSequence();

        int _n;
        int _k;

        private void Read()
        {
            _n = 3; 
            _k = 3;
        }

        public void Do()
        {
            Read();
            var res = GetSequence(_n, _k);
        }

        private string GetSequence(int n , int k)
        {
            int[] factorials = new int[n];
            List<int> nums = new List<int>();
            nums.Add(1);

            factorials[0] = 1;
            for(int i = 1; i < n; i++) 
            {
                // generate factorial system bases 0!, 1!, ..., (n - 1)!
                factorials[i] = factorials[i - 1] * i;
                // generate nums 1, 2, ..., n
                nums.Add(i + 1);
            }

            // fit k in the interval 0 ... (n! - 1)
            k--;

            // compute factorial representation of k
            StringBuilder sb = new StringBuilder();
            for (int i = n - 1; i > -1; --i) 
            {
                int idx = k / factorials[i];
                k -= idx * factorials[i];

                sb.Append(nums[idx]);
                nums.RemoveAt(idx);
            }
            return sb.ToString();
        }

  int[][] dp;
  int rows, cols;

  public int getMinHealth(int currCell, int nextRow, int nextCol) {
    if (nextRow >= this.rows || nextCol >= this.cols)
      return int.MaxValue;
    int nextCell = this.dp[nextRow][nextCol];
    // hero needs at least 1 point to survive
    return Math.Max(1, nextCell - currCell);
  }

  public int calculateMinimumHP(int[][] dungeon) {
    rows = dungeon.Length;
    cols = dungeon[0].Length;
    dp = new int[rows][];

    for(int i=0; i<rows; i++)
    {
        dp[i] = new int[cols];
        System.Array.Fill(dp[i], int.MaxValue);
    }
    int currCell, rightHealth, downHealth, nextHealth, minHealth;
    for (int row = this.rows - 1; row >= 0; --row) {
      for (int col = this.cols - 1; col >= 0; --col) {
        currCell = dungeon[row][col];

        rightHealth = getMinHealth(currCell, row, col + 1);
        downHealth = getMinHealth(currCell, row + 1, col);
        nextHealth = Math.Min(rightHealth, downHealth);

        if (nextHealth != int.MaxValue) {
          minHealth = nextHealth;
        } else {
          minHealth = currCell >= 0 ? 1 : 1 - currCell;
        }
        this.dp[row][col] = minHealth;
      }
    }
    return this.dp[0][0];
  }
    }
}