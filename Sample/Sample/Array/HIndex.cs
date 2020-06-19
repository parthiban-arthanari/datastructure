using System;

namespace Sample.Array
{
    public class HIndex
    {
        public static HIndex Instance = new HIndex();

        int[] _arr;

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("[0,3,5,6]");
        }

        public void Do()
        {
            Read();
            GetIndex1(_arr);
        }

        private int GetIndex(int[] citations)
        {
            int start = 0;
            int end = citations.Length;
            int mid;
            int hIndex = 0;

            while(start < end)
            {
                mid = start + (end - start) / 2;
                int pos = citations.Length - mid;
                int val = citations[mid];

                if(val > hIndex && pos <= val)
                    hIndex = Math.Max(hIndex, pos);
                
                if(val > pos)
                    end = mid;
                else
                    start = mid + 1;
            }


            return hIndex;
        }

        private int GetIndex1(int[] citations)
        {
           int n = citations.Length;
           int start =0;
           int end = n-1;
           int mid;
           while(start <= end)
           {
               mid = start + (end - start) / 2;
               if(citations[mid] == n - mid) return n - mid;
               if(citations[mid] > n - mid) end = mid -1;
               else start = mid + 1;
           }

           return n - start;
        }
    }
}