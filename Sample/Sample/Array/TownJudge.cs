using System;
using System.Collections.Generic;

namespace Sample
{
    public class TownJudge
    {
        public static TownJudge Istance = new TownJudge();
        int[][] trusts;
        int N;

        public void Do()
        {
            Read();
            JudgeExist(N, trusts);
        }

        private void Read()
        {
            N = 1;
            trusts = new int[1][];

            trusts[0] = new int[]{1,3};
            trusts[1] = new int[]{1,4};
            trusts[2] = new int[]{2,3};
            trusts[3] = new int[]{2,4};
            trusts[4] = new int[]{4,3};
        }

        private int JudgeExist(int N, int[][] trust)
        {
            Dictionary<int, Tuple<int, int>> map = new Dictionary<int, Tuple<int, int>>();

            for(int i =0; i<trust.Length; i++)
            {
                int t = trust[i][0];
                int tr = trust[i][1];

                if(!map.ContainsKey(t))
                    map.Add(t, new Tuple<int, int>(0,0));
                if(!map.ContainsKey(tr))
                    map.Add(tr, new Tuple<int, int>(0,0));

                var temp = map[t];
                map[t] = new Tuple<int, int>(temp.Item1+1, temp.Item2);

                temp = map[tr];
                map[tr] = new Tuple<int, int>(temp.Item1, temp.Item2+1);
            }

            for(int i =1; i<=N; i++)
            {
                if(map.Count > 0)
                {
                    if(!map.ContainsKey(i))
                    {
                        return -1;
                    }

                    if(map[i].Item1 == 0 && map[i].Item2 >= N-1 && map[i].Item2 > 0)
                        return i;
                }
                else if(N == 1)
                    return 1;

            }

            return -1;

        }
    }
    
}