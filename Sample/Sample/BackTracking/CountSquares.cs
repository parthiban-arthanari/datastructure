using System;

namespace Sample.BackTracking
{
    public class CountSquare
    {
        public static CountSquare Instance = new CountSquare();
        int[][] mat;
        int Row, Col;

        public void Do()
        {
            Read();
            Console.WriteLine(CountSquares(mat));
        }

        private void Read()
        {
            mat = new int[3][];

            mat[0] = new int[]{0,1,1,1};
            mat[1] = new int[]{1,1,1,1};
            mat[2] = new int[]{0,1,1,1};

            
        }

        private bool IsValid(int[][] mat, int r, int c, int step)
        {
            bool isValid = false;

            for(int i=r; i< r + step; i++)
            {
                for(int j=c; j<c + step; j++)
                {
                    if(i < Row && j < Col && mat[i][j] == 1)
                        isValid = true;
                    else
                        return false;
                }
            }

            return isValid;
        }

        private int SquareCount(int[][] matrix)
        {
            int count = 0;
            Row = mat.Length;

            if(Row != 0)
                Col = mat[0].Length;

            int step = Row < Col ? Row : Col;

            for(int s = 1; s <= step; s++)
            {
                for(int i =0; i < Row; i++)
                {
                    for(int j=0; j<Col; j++)
                    {
                        if(IsValid(matrix, i, j, s))
                            count++;
                    }
                }
            }

            return count;
        }

        public int CountSquares(int[][] matrix) 
        {
            int total = 0;
            int rows = matrix.Length;
            int cols = matrix[0].Length;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < cols; j++)
                {
                    if(matrix[i][j] == 0)
                        continue;
                    if(i == 0 || j == 0)
                    {
                        total += matrix[i][j];
                        continue;
                    }
                    int min = Math.Min(matrix[i-1][j], Math.Min(matrix[i][j-1], matrix[i-1][j-1]));
                    matrix[i][j] += min;
                    total += matrix[i][j];
                }
            }
            return total;
        }
    }
}