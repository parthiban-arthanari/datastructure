using System;

namespace Sample
{
    public class PerfectSquare
    {
        public static PerfectSquare Instance = new PerfectSquare();
        private int num;

        public void Do()
        {
            Read();
            IsSquare(num);
        }

        private void Read()
        {
            num = 2147395600;
        }

        private bool IsSquare(int num)
        {
            if(num < 2)
                return true;
            
            long left = 2;
            long right = num / 2;
            long x;
            long squared;

            while(left <= right)
            {
                x = left + (right - left ) / 2;
                squared = x * x;

                if(squared == num)
                    return true;
                if( squared > num)
                    right = x - 1;
                else
                    left = x + 1;
            }
            
            return false;
        }

    }
}