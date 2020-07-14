using System;
namespace Sample.BackTracking
{
    public class IslandPerimeter
    {
        public static IslandPerimeter Instance = new IslandPerimeter();
        int[][] mat;
        int[] rowNumber = { -1, 0, 0, 1 };
        int[] colNumber = { 0, -1, 1, 0 };
        int row;
        int col;

        int perimeter;

        private void Read()
        {
            mat = Utility.Convert2DArray<int>("[[0,1,0,0],[1,1,1,0],[0,1,0,0],1,1,0,0]]",4);
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Number of IsLands - {0}", CountIslands(mat));
        }

        public int CountIslands(int[][] mat)
        {
            row = mat.Length;
            col = 0;
            if (row != 0)
                col = mat[0].Length;

            int count = 0;

            bool[,] visited = new bool[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i][j] == 1 && !visited[i, j])
                    {
                        DFS(i, j, mat, visited);
                        count++;
                    }
                }
            }
            return count;
        }

        private void DFS(int i, int j, int[][] mat, bool[,] visited)
        {
            perimeter += 4;
            visited[i, j] = true;

            for (int k = 0; k < 4; k++)
            {
                int r = i+rowNumber[k];
                int c = j+colNumber[k];
                if (IsSafe(i + rowNumber[k], j + colNumber[k], mat, visited, false))
                {
                    DFS(r,c, mat, visited);
                }
            }
            perimeter -= GetIntersectBorders(mat, visited, i,j);
        }

        private bool IsSafe(int i, int j, int[][] mat, bool[,] visited, bool visit)
        {
            if (i >= 0 && i < row && j >= 0 && j < col && mat[i][j] == 1 && visited[i, j] == visit)
                return true;
            return false;
        }

        private int GetIntersectBorders(int[][] mat, bool[,] visited, int row, int col)
        {
            int count = 0;

            for(int i=0; i<4;i++)
            {
                int r = row+rowNumber[i];
                int c = col+colNumber[i];
                if (IsSafe(r,  c, mat, visited, true))
                {
                    count += 1;
                }
            }

            return count;
        }
    }
}
