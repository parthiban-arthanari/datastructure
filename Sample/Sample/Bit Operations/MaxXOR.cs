using System;
using System.Collections.Generic;

namespace Sample.Bit
{
    public class MaxXOR
    {
        int[] _arr;
        public static MaxXOR Instance = new MaxXOR();

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("[3, 10, 5, 25, 2, 8]");
        }

        public void Do()
        {
            Read();
            var val = FindMax1(_arr);
        }

        private int FindMax(int[] arr)
        {
            int maxNum = 0;
            foreach(var num in arr) maxNum = Math.Max(maxNum, num);

            int L = Convert.ToString(maxNum, 2).Length;
            int maxXOR = 0, currXOR;
            HashSet<int> prefixes = new HashSet<int>();

            for(int i= L-1; i>=0; i--)
            {
                maxXOR <<=1;
                currXOR = maxXOR | 1;
                prefixes.Clear();

                foreach(var num in arr) prefixes.Add(num >> i);

                foreach(var p in prefixes)
                {
                    if(prefixes.Contains(p ^ currXOR))
                    {
                        maxXOR = currXOR;
                        break;
                    }
                }
            }

            return maxXOR;
        }

        //Using Trie

        public class Trie
        {
            public Dictionary<char, Trie> children = new Dictionary<char, Trie>();
        }

        private int FindMax1(int[] arr)
        {
            int maxNum = 0;
            foreach(var num in arr) maxNum = Math.Max(maxNum, num);
            int L = Convert.ToString(maxNum, 2).Length;
            int bitMask = 1 << L;
            int maxXOR = 0, currXOR;
            Trie triNode = new Trie();
            Trie xorNode;

            foreach(var num in arr)
            {
                string binaryStr = Convert.ToString(bitMask | num, 2).Substring(1);
                xorNode = triNode;
                Trie node = triNode;
                currXOR = 0;
                foreach(var bit in binaryStr)
                {
                    if(node.children.ContainsKey(bit))
                        node = node.children[bit];
                    else
                    {
                        Trie newNode = new Trie();
                        node.children.Add(bit, newNode);
                        node = newNode;
                    }

                    char invertedBit = bit == '1' ? '0' : '1';
                    if(xorNode.children.ContainsKey(invertedBit))
                    {
                        currXOR = (currXOR << 1) | 1;
                        xorNode = xorNode.children[invertedBit];
                    }
                    else
                    {
                        currXOR = currXOR << 1;
                        xorNode = xorNode.children[bit];
                    }
                }
                maxXOR = Math.Max(currXOR, maxXOR);
            }
            return maxXOR;
        }
    }

}