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
                Console.WriteLine("2. Dependency Subject");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 2;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        CheapestPrice.Instance.Do();
                        break;
                    case 2:
                        G_DependentSubject.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}