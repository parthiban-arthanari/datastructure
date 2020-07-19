using System;

namespace Sample.Heap
{
    public class HeapRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Top K Frequent Elements");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        K_FrequentElements.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}