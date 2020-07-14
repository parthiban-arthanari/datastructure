using System;

namespace Sample.LS
{
    public class LSRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Flatten the Multi List");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        FlattenMultiList.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}