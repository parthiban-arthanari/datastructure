using System;
using System.Collections.Generic;

namespace Sample.Graph
{
    public class Graph
    {
        private readonly int _v;
        private int _e;

        private LinkedList<int>[] adjList;
        private int[] indegree;

        public int V
        {
            get { return _v;} 
        }

        public int E
        {
            get { return _e; }
            private set { _e = value; }
        }

        public LinkedList<int>[] AdjList
        {
            get { return adjList; }
        }

        public Graph(int V)
        {
            _v = V;

            adjList = new LinkedList<int>[_v];
            indegree = new int[_v];

            for(int i=0; i<_v; i++)
                adjList[i] = new LinkedList<int>();
        }

        private void ValidateVertex(int u)
        {
            if(u<0 || u > _v)
                throw new ArgumentException(string.Format("vertex {0} is not between 0 aund {1}", u, _v-1));
        }
        public void AddEdge(int u, int v)
        {
            ValidateVertex(u);
            ValidateVertex(v);
            E++;
            adjList[u].AddLast(v);
            indegree[v]++;
        }

        public int InDegree(int u)
        {
            ValidateVertex(u);
            return indegree[u];
        }

        public int OutDegree(int v)
        {
            ValidateVertex(v);
            return adjList[v].Count;
        }

    }
}