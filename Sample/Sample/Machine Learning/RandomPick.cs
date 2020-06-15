using System;

namespace Sample.ML
{
    public class RandomPick
    {
        public static RandomPick Instance = new RandomPick();

        int[] weights;
        int[] prefixSum;

        Random random;

        void Read()
        {
            weights = Utility.ConvertArray<int>("[1]");
            random = new Random();
        }

        public void Do()
        {
            Read();
            Initialize(weights);
            Random();
        }

        private void Initialize(int[] w)
        {
            prefixSum = new int[w.Length];
            int sum = 0;
            for(int i=0; i<w.Length; i++)
            {
                sum += w[i];
                prefixSum[i] = sum;
            }
        }

        private int Random()
        {
            int start = 0;
            int end = prefixSum.Length;
            int r = random.Next(0, prefixSum[end - 1]);

            while(start < end)
            {
                int mid = start + (end - start) / 2;
                if(r < prefixSum[mid])
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return start;
        }
    }
}