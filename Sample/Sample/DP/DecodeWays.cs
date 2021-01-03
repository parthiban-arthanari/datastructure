using System;
using System.Collections.Generic;

namespace Sample.DP
{
    public class DecodeWays
    {
        public static DecodeWays Instance = new DecodeWays();
        string s;
        Dictionary<int, int> dict = new Dictionary<int, int>();
        private void Read()
        {
            s = "0";
        }

        public void Do()
        {
            Read();
            var val = GetDecodeWays(s);

        }

        private int GetDecodeWays(string s)
        {
            int n = s.Length;
            if(string.IsNullOrWhiteSpace(s))
                return 0;
            return Decode(s, 0, n);
        }

        private int Decode(string s, int i, int len)
        {
            if(i == len)
                return 1;
            
            if(s[i] == '0')
                return 0;
            
             if(i == len-1)
                return 1;

            if(dict.ContainsKey(i))
                return dict[i];
            
            int ans = Decode(s, i+1, len);
            if(i+2 <= len && Int32.Parse(s.Substring(i, 2)) <= 26)
                ans += Decode(s, i+2, len);
            
            dict[i] = ans;

            return ans;
        }
    }
}