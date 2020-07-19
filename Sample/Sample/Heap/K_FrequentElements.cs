using System;
using System.Collections.Generic;

namespace Sample.Heap
{
    public class K_FrequentElements
    {
        public static K_FrequentElements Instance = new K_FrequentElements();

        int[] _nums;
        int _k;

        private void Read()
        {
            _nums = Utility.ConvertArray<int>("[4,1,-1,2,-1,2,3]");
            _k = 2;
        }

        public void Do()
        {
            Read();
            var val = TopKFrequent(_nums, _k);
        }

        private int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> coll = new Dictionary<int, int>();
            int[] res = new int[k];

            for(int i=0; i<nums.Length; i++)
            {
                if(!coll.ContainsKey(nums[i]))
                    coll[nums[i]] = 0;
                coll[nums[i]]++;
            }

            Heap<ComparableArray> heap = new Heap<ComparableArray>(k+1, 0, (a,b) => a[1] < b[1]);

            foreach(var item in coll)
            {
                heap.Insert(new ComparableArray(new int[] {item.Key, item.Value}));
                if(heap.Count > k)
                    heap.Delete();
            }

            int index =0;
            while(heap.Count > 0)
            {
                res[index++] = heap.Delete()[0];
            }

            return res;
        }
    }
}