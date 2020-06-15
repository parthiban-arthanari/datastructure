using System;

namespace Sample.Bit
{
    public class BitRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Power of 2");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        PowerOf2.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}