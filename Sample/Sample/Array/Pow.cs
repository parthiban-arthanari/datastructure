using System;

namespace Sample.Array
{
    public class Pow
    {
        public static Pow Instance = new Pow();

        int _n;
        double _x;

        private void Read()
        {
            _x = 3;
            _n = 7;
        }

        public void Do()
        {
            Read();
            var val = FindPow(_x, _n);
        }

        private double FindPow(double x, int n)
        {
            long N = n;
            if (N < 0) 
            {
            x = 1 / x;
            N = -N;
            }
            double ans = 1;
            double current_product = x;
            for (long i = N; i > 0; i /= 2) 
            {
                if ((i % 2) == 1) 
                {
                    ans = ans * current_product;
                }
                current_product = current_product * current_product;
            }
            return ans;
        }

        private double fastPow(double x, long n) 
        {
            if (n == 0) 
            {
                return 1.0;
            }
            double half = fastPow(x, n / 2);
            if (n % 2 == 0) 
            {
                return half * half;
            } 
            else 
            {
                return half * half * x;
            }
    }
        public double myPow(double x, int n) 
        {
            long N = n;
            if (N < 0) 
            {
                x = 1 / x;
                N = -N;
            }

            return fastPow(x, N);
        }

        private double FindPow1(double x, int n)
        {
            bool negative = false;
            if(n < 0)
            {
                negative = true;
                n = -n;
            }
            double[] dp = new double[32];
            dp[0] = 1;
            int i =1;
            int index =1;
            double ans = 1;
            while(i <= n && index < 31)
            {
                dp[index] = ans * x;
                ans *= dp[index];
                i = i<<1;
                index++;
            }
            ans = 1;
            while(n > 0)
            {
                if(n >= i)
                {
                ans *= dp[index];
                n-=i;
                }
                i = i>>1;
                index--;
            }
            return negative ? 1/ans : ans;
            
        }
    }
}