using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.Array
{
    public class SortByFrequency
    {
        public static SortByFrequency Instance = new SortByFrequency();

        string str;

        public void Do()
        {

        }

        private void Read()
        {
            str = "google";
            Sort(str);
        }

        private string Sort(string s)
        {
            Dictionary<char, int> map = new Dictionary<char, int>();
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<s.Length; i++)
            {
                if(map.ContainsKey(s[i]))
                    map[s[i]]++;
                else
                    map[s[i]] = 1;
            }

            foreach(var pair in map.OrderByDescending(key => key.Value))
            {
                

                int count = pair.Value;
                while(count > 0)
                {
                    sb.Append(pair.Key);
                    count--;
                }
            }
            return sb.ToString();
            
        }
    }
}