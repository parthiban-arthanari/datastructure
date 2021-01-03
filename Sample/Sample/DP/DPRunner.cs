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
                Console.WriteLine("4. Minimim Job Difficulty");
                Console.WriteLine("5. CherryPick");
                Console.WriteLine("6. CherryPick2");
                Console.WriteLine("7. Decode Ways");
                Console.WriteLine("8. JumpGame");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 8;

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
                    case 4:
                        MinJobDifficulty.Instance.Do();
                        break;
                    case 5:
                        CherryPick.Instance.Do();
                        break;
                    case 6:
                        CherryPick2.Insatance.Do();
                        break;
                    case 7:
                        DecodeWays.Instance.Do();
                        break;
                    case 8:
                        JumpGame.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}