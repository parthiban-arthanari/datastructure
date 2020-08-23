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
                Console.WriteLine("2. Remove by value");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 2;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        FlattenMultiList.Instance.Do();
                        break;
                    case 2:
                        RemoveItemByValue.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}