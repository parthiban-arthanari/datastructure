using System;
using System.Collections.Generic;

namespace Sample.Heap
{
    public class ShortDistFromOrigin
    {
        public static ShortDistFromOrigin Instance = new ShortDistFromOrigin();
        int[][] _points;
        

        private void Read()
        {
            _points = Utility.Convert2DArray<int>("[[6,10],[-3,3],[-2,5],[0,2]]", 2);
        }

        public void Do()
        {
            Read();
            var res = FindKPoints(_points, 3);
        }

        private int[][] FindKPoints(int[][] points, int K)
        {
            Heap<double> heap = new Heap<double>(points.Length, 0);
            Dictionary<double, List<int[]>> map = new Dictionary<double, List<int[]>>();
            int[][] result = new int[K][];

            for(int i=0; i<points.Length; i++)
            {
                double dist = Dist(points[i]);

                if(!map.ContainsKey(dist))
                    map[dist] = new List<int[]>();

                map[dist].Add(points[i]);

                heap.Insert(dist);
            }

            int index = 0;
            for(int i=0; index< K; i++)
            {
                var list = map[heap.Delete()];

                for(int j =0; j<list.Count && index < K; j++)
                {
                result[index++] = list[j];
                }
            }

            return result;
        }

        private double Dist(int[] a)
        {
            return Math.Sqrt(Math.Pow(a[0], 2) + Math.Pow(a[1], 2));
        }
    }
}