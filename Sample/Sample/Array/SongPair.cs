using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class SongPair
    {
        public static SongPair Instance = new SongPair();
        int[] times;

        private void Read()
        {
            times = Utility.ConvertArray<int>("[30,20,150,100,40, 20]");
        }

        public void Do()
        {
            Read();
            var val = NumPairsDivBy601(times);
        }

        private int NumPairsDivBy60(int[] time)
        {
            Dictionary<int, Tuple<int, int>> dict = new Dictionary<int, Tuple<int, int>>();
            int count = 0;

            for(int i=0; i<time.Length; i++)
            {
                int key = time[i]%60;
                int val = key > 0 ? 60 - key : key;
                Tuple<int, int> pair;
                if(dict.ContainsKey(key))
                {
                    pair = dict[key];
                    count += pair.Item2;
                }
                if(dict.ContainsKey(val))
                {
                    pair = dict[val];
                    dict[val] = Tuple.Create(pair.Item1, pair.Item2+1);
                }
                else
                    dict[val] = Tuple.Create(key, 1);
            }

            return count;
        }

        private int NumPairsDivBy601(int[] time)
        {
            int count = 0;
            int[] rm = new int[60];

            foreach(var t in time)
            {   
                int t1 = t%60;
                count += rm[(60-t1)%60];
                rm[t1]++;
            }

            return count;
        } 
    }
}