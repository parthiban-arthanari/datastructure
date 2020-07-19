using System;
using System.Collections.Generic;

namespace Sample.Graph
{
    public class G_DependentSubject
    {
        public static G_DependentSubject Instance = new G_DependentSubject();
        int numofCourses;
        int[][] dependency;

        private void Read()
        {
            numofCourses = 3;
            dependency = Utility.Convert2DArray<int>("[[1,0],[1,2],[0,1]]", 2);
        }

        public void Do()
        {
            Read();
            var val = FindOrder(numofCourses, dependency);

            Graph graph = new Graph(numofCourses);

            for(int i=0; i<dependency.Length; i++)
                graph.AddEdge(dependency[i][0], dependency[i][1]);

            IsTopologicalSort(graph);
        }

        private bool IsTopologicalSort(Graph g)
        {
            int[] indegree = new int[g.V];
            Queue<int> queue = new Queue<int>();
            int count = 0;

            for(int i=0; i<g.V; i++)
            {
                indegree[i] = g.InDegree(i);
                if(indegree[i] == 0)
                    queue.Enqueue(i);
            }

            while(queue.Count > 0)
            {
                int v = queue.Dequeue();
                count++;

                foreach(var ver in g.AdjList[v])
                {
                    indegree[ver]--;
                    if(indegree[ver] == 0)
                        queue.Enqueue(ver);
                }
            }

            return count == g.V;

        }

        private int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            List<int>[] adj = new List<int>[numCourses];
            int[] indegree = new int[numCourses];
            List<int> order = new List<int>(numCourses);
            bool[] visited = new bool[numofCourses];

            for(int i=0; i<prerequisites.Length; i++)
            {
                int c1 = prerequisites[i][0];
                int c2 = prerequisites[i][1];

                if(adj[c2] == null)
                    adj[c2] = new List<int>();
                
                adj[c2].Add(c1);
                indegree[c1]++;
            }

            Queue<int> queue = new Queue<int>();

            for(int i=0; i<numCourses; i++)
            {
                if(indegree[i]== 0)
                    queue.Enqueue(i);
            }

            while(queue.Count > 0)
            {
                int c = queue.Dequeue();
                order.Add(c);
                
                if(visited[c])
                    break;

                if(adj[c] != null)
                {
                    foreach(var item in adj[c])
                    {
                        indegree[item]--;

                        if(indegree[item] == 0)
                            queue.Enqueue(item);
                    }
                }
                visited[c]=true;
            }

            return order.Count == numofCourses ? order.ToArray() : new int[] {};
        }
    }
}