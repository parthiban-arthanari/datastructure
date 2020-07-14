using System;

namespace Sample.BackTracking
{
    public class BackTrackingRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Find and Flip Region");
               
                // int choice = int.Parse(Console.ReadLine());
                int choice = 2;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        FindAndFlipRegion.Instance.Do();
                        break;
                    case 2:
                        IslandPerimeter.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}