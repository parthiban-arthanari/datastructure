using System;
namespace Sample.Array
{
    public class RotateMatrix
    {
        public static RotateMatrix Instance = new RotateMatrix();
        private int[][] matrix;

        public RotateMatrix()
        {
        }

        public void Do()
        {
            Read();
            int row = matrix.GetLength(0);
            int col = matrix[0].Length;

            for(int i=0; i<=row/2; i++)
            {
                for(int j=i; j< col-i-1; j++)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[col - j - 1][ i];
                    matrix[col - j - 1][i] = matrix[row - i - 1][col - j - 1];
                    matrix[row - i - 1][col - j - 1] = matrix[j][row - i - 1];
                    matrix[j][row - i - 1] = temp;
                }
            }
      
            
        }

        private void Read()
        {
            matrix = new int[3][];

            matrix[0] = new int[3] { 1, 2, 3 };
            matrix[1] = new int[3] { 4, 5, 6 };
            matrix[2] = new int[3] { 7, 8, 9 };

        }
    }
}
