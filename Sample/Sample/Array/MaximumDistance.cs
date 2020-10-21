using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class MaximumDistance
    {
        List<List<int>> arr = new List<List<int>>();

        private void Read()
        {

        }

        public void Do()
        {

        }

        int MaxDistance(IList<IList<int>> arr)
        {
            int dist =0;
            int min = arr[0][0], max = arr[0][arr[0].Count -1];

            for(int i=1; i<arr.Count; i++)
            {
                dist = Math.Max(dist, Math.Max(Math.Abs(max - arr[i][0]), Math.Abs(arr[i][arr[i].Count -1] - min)));
                min = Math.Min(min, arr[i][0]);
                max = Math.Max(max, arr[i][arr[i].Count -1]);
            }

            return dist;
        }
    }

    class RecentCounter {
    LinkedList<int> slideWindow;

    public RecentCounter() {
        this.slideWindow = new LinkedList<int>();
    }

    public int ping(int t) {
        // step 1). append the current call
        this.slideWindow.AddLast(t);

        // step 2). invalidate the outdated pings
        while (this.slideWindow.First.Value < t - 3000)
            this.slideWindow.RemoveFirst();

        return this.slideWindow.Count;
    }
}

}