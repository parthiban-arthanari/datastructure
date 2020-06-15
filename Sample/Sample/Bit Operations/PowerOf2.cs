using System;

namespace  Sample.Bit
{
    public class PowerOf2
    {
        public static PowerOf2 Instance = new PowerOf2();

        int num;

        private void Read()
        {
            num = -2147483648;
        }

        public void Do()
        {
            Read();
            IsPower(num);
        }

        private bool IsPower(int n)
        {
            if( n==0) return false;

            return (n & (-n)) == n;

        }


        private bool IsPower1(int n)
        {
            if( n==0) return false;

            return (n & (n-1)) == 0;

        }
    }
}
