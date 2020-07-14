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
                Console.WriteLine("3. Hamming Distance");
                Console.WriteLine("3. Reverse Bits");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 3;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        PowerOf2.Instance.Do();
                        break;
                    case 2:
                        HammingDist.Instance.Do();
                        break;
                    case 3:
                        ReverseBits.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}