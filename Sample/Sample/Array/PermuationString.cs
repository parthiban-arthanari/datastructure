using System;
using System.Collections.Generic;

namespace  Sample.Array
{
    public class PermutationString
    {
        public static PermutationString Instance = new PermutationString();

        string _s1;
        string _s2;

        public void Do()
        {
            Read();
            CheckInclusion(_s1, _s2);
        }

        private void Read()
        {
            _s1 = "ab";
            _s2 = "eidbaooo";
        }

        private bool CheckInclusion(string s1, string s2)
        {
            int n1 = s1.Length;
            int n2 = s2.Length;

            if(n2 < n1)
                return false;
            
            Dictionary<char, int> map = new Dictionary<char, int>();

            for(int i =0; i<n1; i++)
            {
                if(map.ContainsKey(s1[i]))
                    map[s1[i]]++;
                else
                    map[s1[i]] = 1;
            }

            Dictionary<char, int> smap = new Dictionary<char, int>();

            for(int i =0; i<n2; i++)
            {
                char ch = s2[i];

                if(smap.ContainsKey(ch))
                    smap[ch]++;
                else
                    smap[ch] = 1;
                
                if(i>= n1)
                {
                    ch = s2[i-n1];

                    if(smap[ch] == 1)
                        smap.Remove(ch);
                    else
                        smap[ch]--;
                }

                if(IsDictEquals<char, int>(smap, map))
                    return true;
            }

            return false;
        }

        private bool IsDictEquals<TKey, TValue>(Dictionary<TKey, TValue> d, Dictionary<TKey, TValue> d2)
        {
            bool equal = false;
            if (d.Count == d2.Count) 
            {    // Require equal count.
                equal = true;
                foreach (var pair in d) 
                {
                    TValue value;
                    if (d2.TryGetValue(pair.Key, out value)) 
                    {
                        if (!value.Equals(pair.Value)) 
                        {
                            equal = false;
                            break;
                        }
                    } 
                    else 
                    {
                        equal = false;
                        break;
                    }
                }
            }

            return equal;
        }
    }
}