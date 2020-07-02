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
                Console.WriteLine("2. Unique BST");
                Console.WriteLine("3. Sum Root to Leaf");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 3;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        SearchNode.Instance.Do();
                        break;
                    case 2:
                        UniqueBST.Instance.Do();
                        break;
                    case 3:
                        SumRootToLeaf.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}