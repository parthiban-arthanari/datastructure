using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class LongestDuplicateSubstring
    {
        public static LongestDuplicateSubstring Instance = new LongestDuplicateSubstring();

        string s;
        // int p1,p2, l, maxl, index;
        // char[] sub;

        private void Read()
        {
            s = "Banana";
            // sub = new char[s.Length];
        }

        public void Do()
        {
            Read();
            // string res = Find(s);
            string res = LongestDupSubstring(s);
        }

        // private string Find(string s)
        // {
        //     p1 = 0;
        //     int n = s.Length;
        //     while(p1 < n)
        //     {
        //         p2 = p1+1;
        //         int temp = p1;
        //         while(p2 < n)
        //         {
        //             if(s[temp] == s[p2])
        //             {
        //                 temp++;
        //                 sub[l++] = s[p2];
        //             }
        //             else
        //             {
        //                 if(l > maxl)
        //                 {
        //                     maxl = l;
        //                     index = p1;
        //                 }
        //                 l =0;
        //                 temp = p1;
        //             }
        //             p2++;
        //         }
        //         if(l > maxl)
        //         {
        //             maxl = l;
        //             index = p1;
        //         }
        //         l =0;
        //         p1++;
        //     }

        //     return s.Substring(index, maxl);
        // }

        public String LongestDupSubstring(String S) 
        {
            int n = S.Length;
            // convert string to array of integers
            // to implement constant time slice
            // int[] nums = new int[n];
            // for(int i = 0; i < n; ++i) nums[i] = S[i] - 'a';
            // base value for the rolling hash function
            // int a = 26;
            // modulus value for the rolling hash function to avoid overflow
            // long modulus = (long)Math.Pow(2, 32);

            // binary search, L = repeating string length
            int left = 1, right = n;
            int L;
            while (left <= right) 
            {
                L = left + (right - left) / 2;
                if (search(L, n, S) != -1) left = L + 1;
                else right = L - 1;
            }

            int start = search(left - 1, n, S);
            return S.Substring(start, left - 1);
        }

        public int search(int L, int n, string s) 
        {
            // compute the hash of string S[:L]
            // long h = 0;
            // for(int i = 0; i < L; ++i) h = (h * a + nums[i]) % modulus;

            // already seen hashes of strings of length L
            HashSet<string> seen = new HashSet<string>();
            // seen.Add(s.Substring(0,L));
            // const value to be used often : a**L % modulus
            // long aL = 1;
            // for (int i = 1; i <= L; ++i) aL = (aL * a) % modulus;

            for(int start = 1; start < n - L + 1; ++start) 
            {
                
                // compute rolling hash in O(1) time
                // h = (h * a - nums[start - 1] * aL % modulus + modulus) % modulus;
                // h = (h + nums[start + L - 1]) % modulus;
                string sub = s.Substring(start -1, start + L - 1);
                if (seen.Contains(sub)) 
                {
                    return start;
                }
                seen.Add(sub);
            }
            return -1;
        }

         public String LongestDupSubstring1(String S) 
        {
            int n = S.Length;
            
            int[] nums = new int[n];
            for(int i = 0; i < n; ++i) nums[i] = S[i] - 'a';

            int a = 26;
            
            long modulus = (long)Math.Pow(2, 32);

            
            int left = 1, right = n;
            int L;
            while (left <= right) 
            {
                L = left + (right - left) / 2;
                if (search1(L, a, modulus, n, nums) != -1) left = L + 1;
                else right = L - 1;
            }

            int start = search1(left - 1, a, modulus, n, nums);
            return S.Substring(start, left - 1);
        }

        public int search1(int L, int a, long modulus, int n, int[] nums) 
        {
            
            long h = 0;
            for(int i = 0; i < L; ++i) h = (h * a + nums[i]) % modulus;

            
            HashSet<long> seen = new HashSet<long>();
            seen.Add(h);
            
            long aL = 1;
            for (int i = 1; i <= L; ++i) aL = (aL * a) % modulus;

            for(int start = 1; start < n - L + 1; ++start) 
            {
                h = (h * a - nums[start - 1] * aL % modulus + modulus) % modulus;
                h = (h + nums[start + L - 1]) % modulus;
                if (seen.Contains(h)) 
                {
                    return start;
                }
                seen.Add(h);
            }
            return -1;
        }
    }
}