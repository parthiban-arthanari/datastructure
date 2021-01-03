using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class LongestSubstringAtMostK
    {
        public static LongestSubstringAtMostK Instance = new LongestSubstringAtMostK();

        string s;

        private void Read()
        {
            s = "eceba";
        }

        public void Do()
        {
            Read();
            var val = GetSubstring(s);
        }

        private int GetSubstring(string s)
        {
            int n = s.Length;
            if (n < 3) return n;

            int left = 0;
            int right = 0;
            
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int max_len = 2;

            // while (right < n) 
            // {
            //     if(!dict.ContainsKey(s[right]))
            //         dict[s[right]] = right++;
            //     dict.put(s.charAt(right), right++);

            //     // slidewindow contains 3 characters
            //     if (hashmap.size() == 3) {
            //         // delete the leftmost character
            //         int del_idx = Collections.min(hashmap.values());
            //         hashmap.remove(s.charAt(del_idx));
            //         // move left pointer of the slidewindow
            //         left = del_idx + 1;
            // }

            // max_len = Math.max(max_len, right - left);
            // }
            return max_len;
        }
    }
}