using System;

namespace Sample.Graph
{
    public class GraphRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Cheapest Price");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        CheapestPrice.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}