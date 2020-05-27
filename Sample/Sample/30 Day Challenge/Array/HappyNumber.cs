using System;
namespace Sample.DayChallenge
{
    public class HappyNumber
    {
        public static HappyNumber Instnace = new HappyNumber();
        int num;

        private void Read()
        {
            num = 1111111;
        }

        public void Do()
        {
            Read();
            Console.WriteLine("Given Number is Happy Number - {0}", IsHappyNumber(num));
        }

        private string IsHappyNumber(int num)
        {
            while(true)
            {
                int squareSum = 0;
                while(num > 0)
                {
                    int value = num % 10;
                    squareSum = squareSum + value * value;
                    num = num / 10;
                }

                num = squareSum;
                if (num / 10 == 0)
                    break;
                num = squareSum;
            }

            if (num % 10 == 1)
                return true.ToString();
            return false.ToString();
        }
    }
}
