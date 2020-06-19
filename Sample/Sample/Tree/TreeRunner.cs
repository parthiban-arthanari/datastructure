using System;

namespace Sample.Tree
{
        public class TreeRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Search BST");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 1;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        SearchNode.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}