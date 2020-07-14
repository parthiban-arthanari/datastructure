using System;

namespace Sample.Array
{
    public class PrisonCell
    {
        public static PrisonCell Instance = new PrisonCell();

        int[] cells = new int[8];
        int N;

        private void Read()
        {
            cells = new int[]{0,1,0,1,1,0,0,1};
            N =7;
        }

        public void Do()
        {
            Read();
            var val = AfterDays(cells, N);
        }

        private int[] AfterDays(int[] cells , int N)
        {
            int[] temp = new int[8];
            for(int i=0; i<N; i++)
            {
                for(int j=0; j<8; j++)
                {
                    if(j>0 && j<7 && cells[j-1] == cells[j+1])
                        temp[j] = 1;
                    else
                        temp[j] = 0;
                }
                System.Array.Copy(temp, cells, 8);
            }

            return cells;
        }
    }
}