using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class GroupPeople
    {
        public static GroupPeople Instance = new GroupPeople();
        List<int>[] graph;
        Dictionary<int, int> color;

        int[][] arr;

        private void Read()
        {
            arr = Utility.Convert2DArray<int>("[[1,2],[2,3],[3,4],[4,5],[1,5]]", 2);
        }

        public void Do()
        {
            Read();
            Console.WriteLine(CanGroup1(5, arr).ToString());
        }

        private bool CanGroup(int N, int[][] dislikes)
        {
            Dictionary<int, int> people = new Dictionary<int, int>();

            for(int i=0; i<dislikes.Length; i++)
            {
                int p1 = dislikes[i][0];
                int p2 = dislikes[i][1];
                if(people.ContainsKey(p1) && people.ContainsKey(p2) && people[p1] == people[p2])
                    return false;
                
                if(people.ContainsKey(p1))
                {
                    if(people[p1] == 1)
                    {
                        people[p2] = 2;
                    }
                    else
                    {
                        people[p2] = 1;
                    }
                }
                else if(people.ContainsKey(p2))
                {
                    if(people[p2] == 1)
                    {
                        people[p1] = 2;
                    }
                    else
                    {
                        people[p1] = 1;
                    }
                }
                else
                {
                    people[p1] = 1;
                    people[p2] = 2;
                }
            }
            
            return true;
        }

        private bool CanGroup1(int N, int[][] dislikes)
        {
            graph = new List<int>[N+1];

            for(int i=1; i<=N; i++)
            {
                graph[i] = new List<int>();
            }

            foreach(var edge in dislikes)
            {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            color = new Dictionary<int, int>();

            for(int i =1; i<=N ; i++)
            {
                if(!color.ContainsKey(i))
                {
                    if(!DFS(i, 0))
                    {
                        return false;
                    }
                }
                 
            }

            return true;
        }

        private bool DFS(int node, int c)
        {
            if(color.ContainsKey(node))
                return color[node] == c;
            
            color.Add(node, c);

            foreach(var nei in graph[node])
            {
                if(!DFS(nei, c ^ 1))
                    return false;
            }

            return true;
        }
    }
}