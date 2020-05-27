using System;
using System.Collections.Generic;

namespace Sample
{
    public class RansonNote
    {
        public static RansonNote Instance = new RansonNote();
        private string ransom;
        private string magazine;

        private void Read()
        {
            //ransom = "aa";
            //magazine = "aab";

            ransom = "bjaajgea";
            magazine = "affhiiicabhbdchbidghccijjbfjfhjeddgggbajhidhjchiedhdibgeaecffbbbefiabjdhggihccec";
        }

        public void Do()
        {
            Read();
            Console.WriteLine(CanRansomNote(ransom, magazine).ToString());
        }

        private bool CanRansomNote(string ransomNote, string magazine)
        {
            int r = ransomNote.Length;
            int m = magazine.Length;

            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int i = 0; i < m; i++)
            {
                if (map.ContainsKey(magazine[i]))
                    map[magazine[i]]++;
                else
                    map[magazine[i]] = 1;
            }

            for(int i =0; i<r; i++)
            {
                if (map[ransomNote[i]] > 0)
                    map[ransomNote[i]]--;
                else
                    return false;
            }

            return true;
        }

    }
}
