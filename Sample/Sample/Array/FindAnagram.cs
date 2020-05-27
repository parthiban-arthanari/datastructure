using System;
using System.Collections.Generic;

namespace  Sample.Array
{
    public class FindAnagram
    {
        public static FindAnagram Instance = new FindAnagram();

        string str;
        string _p;

        Dictionary<char, int> map = new Dictionary<char, int>();

        public void Do()
        {
            Read();
            Anagrams(str, _p);
        }

        private List<int> Anagrams(string s, string p)
        {
            List<int> index = new List<int>();
            int ns = s.Length;
            int np = p.Length;

            if(ns < np)
             return index;

            Dictionary<char,int> pCount = new Dictionary<char, int>();
            Dictionary<char, int> sCount = new Dictionary<char, int>();
            
            for(int i = 0; i< np; i++)
            {
                if(pCount.ContainsKey(p[i]))
                    pCount[p[i]]++;
                else
                    pCount[p[i]] = 1;
            }

            for(int i =0; i< ns; i++)
            {
                char ch = s[i];

                if(sCount.ContainsKey(ch))
                    sCount[ch]++;
                else
                    sCount[ch] = 1;
                

                if(i>= np)
                {
                    ch = s[i-np];

                    if(sCount[ch] == 1)
                        sCount.Remove(ch);
                    else
                        sCount[ch]--;
                }

                if(IsDictEquals<char, int>(sCount, pCount))
                    index.Add(i-np+1);
            }
           
            return index;
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

        private void Read()
        {
            str = "abacbabc";
            _p = "abc";
        }

        private void Set(string p)
        {
            map.Clear();
            for(int i =0; i<p.Length; i++)
            {
                if(map.ContainsKey(p[i]))
                    map[p[i]]++;
                else
                    map[p[i]] = 1;
            }
        }

        private bool IsContains(char c)
        {
            if(map.ContainsKey(c))
            {
                if(map[c] > 1)
                {
                    map[c]--;
                }
                else
                {
                    map.Remove(c);
                }

                return true;
            }

            return false;
        }
    }
}