using System;

namespace Sample
{
    public class FindBinaryCompliment
    {
        public static FindBinaryCompliment Instance = new FindBinaryCompliment();
        private int num;

        public void Do()
        {
            Read();
            Console.WriteLine("Binary Compliment : {0}", FindCompliment(num));
        }

        private int FindCompliment(int num)
        {
            string binary = Convert.ToString(num, 2);
            double number = 0;
            for(int i=0; i<binary.Length;i++)
            {
                int value = binary[binary.Length - 1 - i] == '0' ? 1 : 0;
                number = number + value * Math.Pow(2, i);
            }

            return Convert.ToInt32(number);
        }

        private void Read()
        {
            num = 5;
        }
    }
}