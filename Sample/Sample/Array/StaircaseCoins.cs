using System;

namespace  Sample.Array
{
    public class StaircaseCoins
    {
        public static StaircaseCoins Instance = new StaircaseCoins();

        int coins;

        private void Read()
        {
            coins = 8;
        }

        public void Do()
        {
            Read();
            int val = Arrange(coins);
        }

        private int Arrange(int n)
        {
            int i = 1;
            while(n >= i)
            {
                n -= i;
                i++;
            }

            return i-1;
        }
    }
}