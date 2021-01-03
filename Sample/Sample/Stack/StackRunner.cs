using System;

namespace Sample.Stack
{
    public class StackRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Histogram");
                
                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        Histogram.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}