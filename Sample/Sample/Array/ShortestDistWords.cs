using System;
using Sample;

namespace Sample.Array
{
    public class ShortestDistWords
    {
        public static ShortestDistWords Instance = new ShortestDistWords();

        private string word1, word2;
        private string[] words;

        private void Read()
        {
            words = Utility.ConvertArray<string>("[practice,makes,perfect,coding,makes]");
            word1 = "makes";
            word2 = "coding";
        }

        public void Do()
        {
            Read();
            var val = ShortestDist(words, word1, word2);
        }

        private int ShortestDist(string[] words, string word1, string word2)
        {
            int index = -1;
            int shortDist = int.MaxValue;
            string found = string.Empty;

            for(int i=0; i<words.Length; i++)
            {
                if(word1.Equals(words[i]) || word2.Equals(words[i]))
                {
                    if(index < 0)
                    {
                        index = i;
                        found = words[i];
                    }
                    else
                    {
                        if(!found.Equals(words[i]))
                        {
                        shortDist = Math.Min(shortDist, i-index);
                        found = words[i];
                        }
                        index = i;
                    }
                }
            }

            return shortDist;
        }

        private int ShortDist1(string[] words, string word1, string word2)
        {
            int i1 = -1, i2 = -1;
            int minDist = words.Length;

            for(int i =0; i<words.Length; i++)
            {
                if(words[i].Equals(word1))
                    i1 = i;
                else if(words[i].Equals(word2))
                    i2 = i;
                
                if(i1 != -1 && i2 != -1)
                    minDist = Math.Min(minDist, Math.Abs(i1-i2));
            }

            return minDist;
        }
    }
}