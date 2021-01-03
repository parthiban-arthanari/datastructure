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
                Console.WriteLine("2. IslandPerimeter");
                Console.WriteLine("3. SearchWord");
                Console.WriteLine("4. RobotTrajectory");
                Console.WriteLine("5. Cherry Pick");
               
                // int choice = int.Parse(Console.ReadLine());
                int choice = 5;

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
                    case 3:
                        SearchWord.Instance.Do();
                        break;
                    case 4:
                        RobotTrajectory.Instance.Do();
                        break;
                    case 5:
                        CherryPick.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}