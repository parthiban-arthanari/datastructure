using System;

namespace Sample.Array
{
    public class ArrayRunner
    {
        public void Run()
        {
            while(true)
            {
                Console.WriteLine("1. Towers Of Hanoi");
                Console.WriteLine("2. ReverseString");
                Console.WriteLine("3. Rearrange Queue");
                Console.WriteLine("4. Search Insert");
                Console.WriteLine("5. ReorderColor");
                Console.WriteLine("6. InsertDeleteRandom");
                Console.WriteLine("7. LargestDivisibleSubset");
                Console.WriteLine("8. HIndex");
                Console.WriteLine("9. Longest Duplicate Substring");
                Console.WriteLine("10. Permutation Sequence");
                Console.WriteLine("11. Find Single Number from Triplet");
                Console.WriteLine("12. Find Duplicate");
                Console.WriteLine("13. Test");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 13;

                switch(choice)
                {
                    case 0:
                        return;
                    case 1:
                        TowersOfHanoi.Instance.Do();
                        break;
                    case 2:
                        ReverseString.Instance.Do();
                        break;
                    case 3:
                        RearrangeQueue.Instance.Do();
                        break;
                    case 4:
                        SearchInsert.Instance.Do();
                        break;
                    case 5:
                        ReOrderColor.Instance.Do();
                        break;
                    case 6:
                        InserDeleteRandom.Instance.Do();
                        break;
                    case 7:
                        LargestDivisibleSubset.Instance.Do();
                        break;
                    case 8:
                        HIndex.Instance.Do();
                        break;
                    case 9:
                        LongestDuplicateSubstring.Instance.Do();
                        break;
                    case 10:
                        PermutationSequence.Instance.Do();
                        break;
                    case 11:
                        SingleNumber.Instance.Do();
                        break;
                    case 12:
                        FindDuplicate.Instance.Do();
                        break;
                    case 13:
                        StaircaseCoins.Instance.Do();
                        break;
                        
                }

                Console.ReadKey();

            }
        }
    }
}