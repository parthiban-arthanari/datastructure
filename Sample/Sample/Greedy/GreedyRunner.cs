using System;

namespace Sample.Greedy
{
    public class GreedyRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. City Scheduling");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        CityScheduling.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}