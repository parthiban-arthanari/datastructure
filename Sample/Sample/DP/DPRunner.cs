using System;

namespace Sample.DP
{
    public class DPRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. CoinChange");
                Console.WriteLine("2. LCS");
                Console.WriteLine("3. Least perfect Square");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 3;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        CoinChange2.Instance.Do();
                        break;
                    case 2:
                        LCS.Instance.Do();
                        break;
                    case 3:
                        LeastPerfectSquare.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}