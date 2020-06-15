using System;

namespace Sample.ML
{
    public class MLRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Random Index with Weight");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        RandomPick.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}