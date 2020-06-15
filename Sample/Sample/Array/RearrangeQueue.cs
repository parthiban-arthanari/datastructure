using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class RearrangeQueue
    {
        public static RearrangeQueue Instance = new RearrangeQueue();

        private int[][] arr;

        private void Read()
        {
            arr = Utility.Convert2DArray<int>("[[8,2],[4,2],[4,5],[2,0],[7,2],[1,4],[9,1],[3,1],[9,0],[1,0]]", 2);
        }

        public void Do()
        {
            Read();
            Rearrange1(arr);
        }

        private int[][] Rearrange(int[][] people)
        {
            System.Array.Sort(people, new Descending());
            int next = int.MinValue;
            int nextCount = 0;
            bool[] visited = new bool[people.Length];
            int count;
            for(int i=0; i<people.Length; i++)
            {
                var temp = GetNext(next, people, visited);
                next = temp[0];
                nextCount = temp[1];
                int sourceIndex = temp[2];
                int targetIndex = 0;
                count = 0;
                for(int j=0; j<people.Length; j++)
                {
                    int[] val = people[j];
                    if(visited[j] && val[0] < next)
                        continue;

                    if(count <= nextCount)
                    {
                        count++;
                        targetIndex = j;
                    }
                    else
                    {
                        break;
                    }

                    
                }
                var temp1 = people[sourceIndex];
                people[sourceIndex] = people[targetIndex];
                people[targetIndex] = temp1;
                visited[targetIndex] = true;
            }

            return people;
        }

        private int[][] Rearrange1(int[][] people)
        {
            System.Array.Sort(people, new Descending());

            List<int[]> list = new List<int[]>();

            for(int i=0; i<people.Length; i++)
            {
                list.Insert(people[i][1], people[i]);
            }

            return list.ToArray();
        }

        private int[] GetNext(int pre, int[][] people, bool[] visited)
        {
            int next = int.MaxValue;
            int nextCount = 0;
            int index = -1;
            for(int i=0; i<people.Length; i++)
            {
                int val = people[i][0];

                if(!visited[i] && val <= next && val >= pre)
                {
                    next = val;
                    nextCount = people[i][1];
                    index = i;
                }
            }

            return new int[]{next, nextCount, index};
        }
    }

    public class Descending : IComparer<int[]>
    {
        public int Compare(int[] o1, int[] o2)
        {
             return o1[0] == o2[0] ? o1[1] - o2[1] : o2[0] - o1[0];
        }
    }
}