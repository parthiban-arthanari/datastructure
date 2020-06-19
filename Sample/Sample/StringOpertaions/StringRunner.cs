using System;

namespace Sample.StringOperations
{
    public class StringRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Valid IP");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        ValidIP.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}