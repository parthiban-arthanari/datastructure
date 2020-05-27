using System;
using Sample.Microsoft.Backtracking;
using Sample.Microsoft.Array;

namespace Sample.Microsoft
{
    public class MSProgramRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. TwoSum");
                Console.WriteLine("2. FloodFill");
                Console.WriteLine("3. FindOdd");
                Console.WriteLine("4. Check Palindrome");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 4;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        TwoSum.Instance.Do();
                        break;
                    case 2:
                        FillColor.Instance.Do();
                        break;
                    case 3:
                        FindOdd.Instance.Do();
                        break;
                    case 4:
                        CheckPalindrome.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
            


        }
    }
}