using System;
namespace Sample.DayChallenge
{
    public class NumberOfIlands
    {
        public static NumberOfIlands Instance = new NumberOfIlands();
        char[][] mat;
        int[] rowNumber = { -1, 0, 0, 1 };
        int[] colNumber = { 0, -1, 1, 0 };
        int row;
        int col;

        private void Read()
        {
            mat = new char[4][];

            mat[0] = new char[] { '1', '1', '0', '0', '0' };
            mat[1] = new char[] { '1', '1', '0', '0', '0' };
            mat[2] = new char[] { '0', '0', '1', '0', '0' };
            mat[3] = new char[] { '0', '0', '0', '1', '1' };
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Number of IsLands - {0}", CountIslands(mat));
        }

        public int CountIslands(char[][] mat)
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
                    if (mat[i][j] == '1' && !visited[i, j])
                    {
                        DFS(i, j, mat, visited);
                        count++;
                    }
                }
            }
            return count;
        }

        private void DFS(int i, int j, char[][] mat, bool[,] visited)
        {
            visited[i, j] = true;

            for (int k = 0; k < 4; k++)
            {
                if (IsSafe(i + rowNumber[k], j + colNumber[k], mat, visited))
                    DFS(i + rowNumber[k], j + colNumber[k], mat, visited);
            }
        }

        private bool IsSafe(int i, int j, char[][] mat, bool[,] visited)
        {
            if (i >= 0 && i < row && j >= 0 && j < col && mat[i][j] == '1' && !visited[i, j])
                return true;
            return false;
        }
    }
}
