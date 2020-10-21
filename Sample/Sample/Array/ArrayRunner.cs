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
                Console.WriteLine("11. Find N Duplicates");
                Console.WriteLine("12. Find Duplicate");
                Console.WriteLine("13. Test");
                Console.WriteLine("14. Prison After days");
                Console.WriteLine("15. Convert array to sum plus one");
                Console.WriteLine("16. Find Sun of Three numbers is zero");
                Console.WriteLine("17. Subsets");
                Console.WriteLine("18. Angle Between Clock");
                Console.WriteLine("19. Reverse string by word");
                Console.WriteLine("20. Find power of n");
                Console.WriteLine("21. MaxProfit");
                Console.WriteLine("22. Majority Element");

                // int choice = int.Parse(Console.ReadLine());
                int choice = 22;

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
                        FindNDuplicates.Instance.Do();
                        break;
                    case 12:
                        FindDuplicate.Instance.Do();
                        break;
                    case 13:
                        StaircaseCoins.Instance.Do();
                        break;
                    case 14:
                        PrisonCell.Instance.Do();
                        break;
                    case 15:
                        PlusOne.Instance.Do();
                        break;
                    case 16:
                        ThreeSum.Instance.Do();
                        break;
                    case 17:
                        Subset.Instance.Do();
                        break;
                    case 18:
                        AngleBwClock.Instance.Do();
                        break;
                    case 19:
                        ReverseStringByWord.Instance.Do();
                        break;
                    case 20:
                        Pow.Instance.Do();
                        break;
                    case 21:
                        MaxProfit.Instance.Do();
                        break;
                    case 22:
                        MajorityElement.Instance.Do();
                        break;
                }

                Console.ReadKey();

            }
        }
    }
}