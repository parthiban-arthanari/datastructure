using System;

namespace Sample.Algorithm
{
    public class AlgorithmRunner
    {
         public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Boyer-Moore Voting");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                }

                Console.ReadKey();
            }
        }
    }
}