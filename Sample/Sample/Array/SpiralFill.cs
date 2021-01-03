using System;

namespace Sample.Array
{
    public class SpiralFill
    {
        public static SpiralFill Instance = new SpiralFill();
        int n;

        private void Read()
        {
            n=4;
        }

        public void Do()
        {
            Read();
            var val = Fill(n);
        }

        private int[][] Fill(int n)
        {
            int r = 0, c=-1;
            int[][] mat = new int[n][];
            int count = 1;

            for(int i=0; i<n; i++)
            {
                mat[i] = new int[n];
                System.Array.Fill(mat[i], -1);
            }

            int[,] moves = new int[,] {{0,1}, {1,0}, {0,-1}, {-1,0}};

            for(int k=0; k<2*n-1; k++)
            {
                int r1 = r + moves[k%4,0];
                int c1 = c + moves[k%4,1];

                while(InRange(r1,c1,n) && mat[r1][c1] == -1)
                {
                    mat[r1][c1] = count++;
                    r = r1;
                    c = c1;

                    r1 = r + moves[k%4,0];
                    c1 = c + moves[k%4,1];
                }

            }

            return mat;
        }

        private bool InRange(int i, int j, int n)
        {
            return (i>=0) && (i<n) && (j>=0) && (j<n);
        }
    }
}