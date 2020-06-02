using System;

namespace Sample.Array
{
    public class CountingBits
    {
        public static CountingBits Instance = new CountingBits();

        int num;

        private void Read()
        {
            num = 5;
        }

        public void Do()
        {
            Read();
            Count(num);
        }

        private int[] Count(int num)
        {
            int len = 1;
            int[] map = new int[num + 1];
            int temp = num;

            if(num == 0)
                return new int[] {0};

            map[0] = 0;
            while(temp > 1)
            {
                temp = temp / 2;
                len++;
            }

            for(int i =0; i<len; i++)
            {
                int r = Convert.ToInt32(Math.Pow(2, i));

                for(int j =0; j<r && r+j <= num; j++)
                {
                    map[r+j] = 1+ map[j];
                }
            }

            return map;
        }
    }
}