using System;
using System.Collections.Generic;
using System.Linq;
using Sample.Queue;
using Sample.Array;
using Sample.Heap;
using Sample.Tree;
using Sample.DayChallenge;
using Sample.Microsoft;
using Sample.Stack;
using Sample.BackTracking;
using Sample.DP;
using Sample.Graph;
using Sample.Greedy;
using Sample.ML;
using Sample.Bit;
using Sample.StringOperations;
using Sample.LS;

namespace Sample
{

    class Program
    {
         static void Main(string[] args)
        {
            // Menu();
            
            var runner = new GraphRunner();
            runner.Run();
        }

        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Select any option (To exit enter '0'");
                Console.WriteLine("1. Find Length of 1 flipping 'm' 0");
                Console.WriteLine("2. Find Pair of Indices form sum");
                Console.WriteLine("3. Rotate Matrix");
                Console.WriteLine("4. BuyAndSell Stock");
                Console.WriteLine("5. Sort Colors");
                Console.WriteLine("6. Find Minimum Cost to Join All Ropes");
                Console.WriteLine("7. Find All paths from root to leaf");
                Console.WriteLine("8. Sum of all left leaves");
                Console.WriteLine("9. Find Single Number(30 Day Challenge)");
                Console.WriteLine("10. MinStack");
                Console.WriteLine("11. BackSpace String Compare");
                Console.WriteLine("12. Diamter of Tree");
                Console.WriteLine("13. Middle of Node");
                Console.WriteLine("14. BackSpace String Compare(Array)");
                Console.WriteLine("15. Stone Smash");
                Console.WriteLine("16. String Shifts");
                Console.WriteLine("17. Maximum Number of 0's and 1's");
                Console.WriteLine("18. Happy Number");
                Console.WriteLine("19. Find Multiply Except Current");
                Console.WriteLine("20. Find given string with Paranthesis balanced");
                Console.WriteLine("21. Number of IsLands");
                Console.WriteLine("22. Bad Version");
                Console.WriteLine("23. Count Jewel Stones");
                Console.WriteLine("24. Ransom Note");
                Console.WriteLine("25. Find Binary Compliment");
                Console.WriteLine("26. First Unique Character");
                Console.WriteLine("27. Majority Element");
                Console.WriteLine("28. FindCousin");
                Console.WriteLine("29. Find Straight Line");
                Console.WriteLine("30. Perfect Square");
                Console.WriteLine("31. Town Judge");
                Console.WriteLine("32. Trie");
                Console.WriteLine("33. MaxSum(Circular Array)");
                Console.WriteLine("34. Anagrams");
                Console.WriteLine("35. Stock Spanner");
                Console.WriteLine("36. K-Smallest");
                Console.WriteLine("37. Count Squares");
                Console.WriteLine("38. IntersectionIntervals");
                Console.WriteLine("39. IntersectionLines");
                Console.WriteLine("40. GroupPeople");
                Console.WriteLine("41. Build BST From Pre");
                Console.WriteLine("42. Count Bits");
                Console.WriteLine("43. Dependent Subject");
                Console.WriteLine("44. Dependent Subject (Graph)");
                Console.WriteLine("45. Invert Tree");
                Console.WriteLine("46. Shortest distance from Origin");
                Console.WriteLine("47. Minimum Operation");
                
                // int option = int.Parse(Console.ReadLine());
                int option = 47;

                switch (option)
                {
                    case 0:
                        return;
                    case 1:
                        MultiplyExceptCurrent.Instance.Do();
                        break;
                    case 2:
                        FindPairOfSum.Instance.Do();
                        break;
                    case 3:
                        RotateMatrix.Instance.Do();
                        break;
                    case 4:
                        BuyAndSellStock.Instance.Do();
                        break;
                    case 5:
                        SortColors.Instance.Do();
                        break;
                    case 6:
                        FindMinCostJoinRopes.Instance.Do();
                        break;
                    case 7:
                        PathOfRootToLeaf.Instance.Do();
                        break;
                    case 8:
                        SumOfLeftLeaves.Instance.Do();
                        break;
                    case 9:
                        SingleNumber.Instance.Do();
                        break;
                    case 10:
                        MinStack.Instance.Do();
                        break;
                    case 11:
                        BackSpaceStringCompare.Instance.Do();
                        break;
                    case 12:
                        DiameterOfTree.Instance.Do();
                        break;
                    case 13:
                        MiddleOfLinkedList.Instance.Do();
                        break;
                    case 14:
                        BackSpaceStrCompare.Instance.Do();
                        break;
                    case 15:
                        StoneSmash.Instance.Do();
                        break;
                    case 16:
                        StringShifts.Instance.Do();
                        break;
                    case 17:
                        NumerOfOnesZeros.Instance.Do();
                        break;
                    case 18:
                        HappyNumber.Instnace.Do();
                        break;
                    case 19:
                        MultiplyExceptCurrent.Instance.Do();
                        break;
                    case 20:
                        BalanceParanthesis.Instance.Do();
                        break;
                    // case 21:
                    //     NumberOfIlands.Instance.Do();
                    //     break;
                    case 22:
                        BadVersion.Instance.Do();
                        break;
                    case 23:
                        CountJewelStones.Instance.Do();
                        break;
                    case 24:
                        RansonNote.Instance.Do();
                        break;
                    case 25:
                        FindBinaryCompliment.Instance.Do();
                        break;
                    case 26:
                        FirstUniqueChar.Instance.Do();
                        break;
                    case 27:
                        MajorityElement.Instance.Do();
                        break;
                    case 28:
                        FindCousin.Instance.Do();
                        break;
                    case 29:
                        FindStraightLine.Instance.Do();
                        break;
                    case 30:
                        PerfectSquare.Instance.Do();
                        break;
                    case 31:
                        TownJudge.Istance.Do();
                        break;
                    case 32:
                        TrieRunner.Instance.Do();
                        break;
                    case 33:
                        MaxSumCircularArray.Instance.Do();
                        break;
                    case 34:
                        FindAnagram.Instance.Do();
                        break;
                    case 35:
                        StockSpanner.Instance.Do();
                        break;
                    case 36:
                        KSmallest.Instance.Do();
                        break;
                    case 37:
                        CountSquare.Instance.Do();
                        break;
                    case 38:
                        IntervalIntersection.Instance.Do();
                        break;
                    case 39:
                        IntersectLines.Instance.Do();
                        break;
                    case 40:
                        GroupPeople.Instance.Do();
                        break;
                    case 41:
                        BSTFromPre.Instance.Do();
                        break;
                    case 42:
                        CountingBits.Instance.Do();
                        break;
                    case 43:
                        DependentSubject.Instance.Do();
                        break;
                    case 44:
                        G_DependentSubject.Instance.Do();
                        break;
                    case 45:
                        InvertTree.Instanc.Do();
                        break;
                    case 46:
                        ShortDistFromOrigin.Instance.Do();
                        break;
                    case 47:
                        MinimumOperation.Instance.Do();
                        break;
                    }

                    Console.ReadKey();
            }
        }        
    }
}
