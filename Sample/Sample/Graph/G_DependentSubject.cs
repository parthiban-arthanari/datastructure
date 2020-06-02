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
            dependency = Utility.Convert2DArray<int>("[[0,1],[0,2],[1,2],[2,1]]", 2);
        }

        public void Do()
        {
            Read();

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
    }
}