using System;
using System.Collections.Generic;

namespace Sample
{
    public class FirstUniqueChar
{
    public static FirstUniqueChar Instance = new FirstUniqueChar();
    string s;

    private void Read()
    {
        s = "acaadcad";
    }

    public void Do()
    {
        Read();
        FindFirstUniqueChar(s);
        // FirstUniqChar(s);
    }

    private int FirstUniqChar(string s)
    {
        int index = -1;
        for(int i=0; i<s.Length; i++)
        {
            index = i;
            for(int j=0; j<s.Length;j++)
            {
                if(s[i] == s[j] && i!=j)
                {
                    index = -1;
                    break;
                }
            }

            if(index != -1)
                break;
        }

        return index;
    }

    private int FindFirstUniqueChar(string s)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();

        for(int i=0; i<s.Length; i++)
        {
            if(map.ContainsKey(s[i]))
                map[s[i]]++;
            else
                map[s[i]] =1;
        }

        for(int i=0; i<s.Length; i++)
        {
            if(map[s[i]] == 1)
                return i;

        }

        return -1;
    }

    private int NextChar(int index, string s)
    {
        int value = -1;
        for(int i = index; i<s.Length; i++)
        {

        }

        return value;
    }
}
}