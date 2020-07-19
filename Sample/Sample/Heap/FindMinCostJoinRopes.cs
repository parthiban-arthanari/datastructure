using System;
namespace Sample.Heap
{
    public class FindMinCostJoinRopes
    {
        public static FindMinCostJoinRopes Instance = new FindMinCostJoinRopes();
        int[] ropes;

        public FindMinCostJoinRopes()
        {
        }

        private void Read()
        {
            ropes = new[] { 2, 5, 6, 7, 3 };
        }

        public void Do()
        {
            Read();

            Heap<int> h = new Heap<int>(ropes.Length, 0, (a, b) => a < b);
            h.BuildHeap(ropes);

            int min_cost = 0;

            while(h.Count > 0)
            {
                int min = h.Delete();
                int sec_min = h.Delete();

                min_cost = min_cost + min + sec_min;

                h.Insert(min_cost);
            }

            Console.WriteLine("Minimun cost to join all ropes:  " + min_cost);

        }
    }
}
