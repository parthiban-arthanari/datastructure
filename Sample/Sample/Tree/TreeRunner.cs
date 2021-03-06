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
                Console.WriteLine("4. Reverse Level Order");
                Console.WriteLine("5. Maximum Width");
                Console.WriteLine("6. ZigZag Traversal");
                Console.WriteLine("7. Count Smaller Number After Itself");
                Console.WriteLine("8. Binary Tree Iterator");
                Console.WriteLine("9. Is Valid Binary Tree");
                Console.WriteLine("10. Nearest Node");
                Console.WriteLine("11. IsBalanced");
                Console.WriteLine("12. Pseudo Polindromic Path");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 12;

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
                    case 4:
                        ReverseLevelOrder.Instance.Do();
                        break;
                    case 5:
                        MaxWidth.Instance.Do();
                        break;
                    case 6:
                        ZigZagTraversal.Instance.Do();
                        break;
                    case 7:
                        NumSmallerAfterItSelf.Instance.Do();
                        break;
                    case 8:
                        BTIterator.Instance.Do();
                        break;
                    case 9:
                        IsvalidBT.Instance.Do();
                        break;
                    case 10:
                        NearestRightNode.Instance.Do();
                        break;
                    case 11:
                        IsBalanced.Instance.Do();
                        break;
                    case 12:
                        PseudoPolindromicPath.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}