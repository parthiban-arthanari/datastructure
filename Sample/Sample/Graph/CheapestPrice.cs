using System;
using System.Collections.Generic;
using Sample.Heap;

namespace Sample.Graph
{
    public class CheapestPrice
    {
        public static CheapestPrice Instance = new CheapestPrice();
        
        int[][] _arr;
        int num;
        int minCost = int.MaxValue;

        
        private void Read()
        {
            num = 3;
            _arr = Utility.Convert2DArray<int>("[[0,1,100],[1,2,100],[0,2,500]]", 3);
        }

        public void Do()
        {
            Read();
            // Find(num, _arr, 0, 2,0);
            findCheapestPrice(num, _arr,0,2,0);
        }

        private int Find(int n, int[][] flights, int src, int dst, int K) 
        {
            List<int>[] _routes = new List<int>[n];
             int[][] _cost = new int[n][];
            for(int i=0; i<n;i++)
            {
                _routes[i] = new List<int>();
                _cost[i] = new int[n];
            }

            for(int i=0; i<flights.Length; i++)
            {
                _routes[flights[i][0]].Add(flights[i][1]);
                _cost[flights[i][0]][flights[i][1]] = flights[i][2];
            }
            DFS(_routes, _cost, src, dst, K, 0);

            return minCost == int.MaxValue ? -1 : minCost; 
        }

        private int DFS(List<int>[] routes, int[][] price, int start, int dest, int maxStop, int cost)
        {
            List<int> adj = routes[start];
            int tempCost = cost;
            if(maxStop >= 0)
            {
                foreach(var item in adj)
                {
                    cost = tempCost + price[start][item];

                    if(dest == item)
                    {
                        minCost = Math.Min(cost, minCost);
                    }
                    else
                    {
                        cost = DFS(routes, price, item, dest, maxStop-1, cost);
                    }
                }
            }

            return cost;
        }

        public int findCheapestPrice(int n, int[][] flights, int src, int dst, int K) 
        {
     
        // Build the adjacency matrix
        int[][] adjMatrix = new int[n][];
        for(int i=0; i<n; i++)
            adjMatrix[i] = new int[n];
            
        foreach(var flight in flights) 
        {
            adjMatrix[flight[0]][flight[1]] = flight[2];
        }
        
        // Shortest distances array
        int[] distances = new int[n];
        
        // Shortest steps array
        int[] currentStops = new int[n];
        System.Array.Fill(distances, int.MaxValue);
        System.Array.Fill(currentStops, int.MaxValue);
        distances[src] = 0;
        currentStops[src] = 0;
        
        // The priority queue would contain (node, cost, stops)
        Heap<int[]> minHeap= new Heap<int[]>(n, 0, (a,b) => a[1] < b[1]);
        minHeap.Insert(new int[]{src, 0, 0});
        
         while (minHeap.Count > 0)
          {
            int[] info = minHeap.GetMaxOrMin();
            int node = info[0], stops = info[2], cost = info[1];
             
             // If destination is reached, return the cost to get here
            if (node == dst) {
                return cost;
            }
             
            // If there are no more steps left, continue 
            if (stops == K + 1) {
                continue;
            }
             
            // Examine and relax all neighboring edges if possible 
            for (int nei = 0; nei < n; nei++) {
                if (adjMatrix[node][nei] > 0) {
                    int dU = cost, dV = distances[nei], wUV = adjMatrix[node][nei];
                    
                    // Better cost?
                    if (dU + wUV < dV) {
                        minHeap.Insert(new int[]{nei, dU + wUV, stops + 1});
                        distances[nei] = dU + wUV;
                    }
                    else if (stops < currentStops[nei]) {
                        
                        // Better steps?
                        minHeap.Insert(new int[]{nei, dU + wUV, stops + 1});
                        currentStops[nei] = stops;
                    }
                }
            }
         }
        
        return distances[dst] == int.MaxValue? -1 : distances[dst];
    }
    }
}