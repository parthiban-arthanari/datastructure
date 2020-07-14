using System;

namespace Sample.Bit
{
    public class HammingDist
    {
        public static HammingDist Instance = new HammingDist();

        int n1,n2;

        private void Read()
        {
            n1 = 1;
            n2 = 4;
        }

        public void Do()
        {
            Read();
            int val = Dist(n1,n2);
        }

        private int Dist(int x, int y)
        {
            int d = x ^ y;
            int sum = 0;


            while(d > 0)
            {
                sum += 1;
                d = d & (d-1);
            }

            return sum;
        }
    }
}