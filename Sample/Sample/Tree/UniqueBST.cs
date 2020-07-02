using System;

namespace Sample.Tree
{
    public class UniqueBST
    {
        public static UniqueBST Instance = new UniqueBST();

        int num;

        private void Read()
        {
            num = 3;
        }

        public void Do()
        {
            Read();
            int val = NumTrees(num);
        }

        private int NumTrees(int n)
        {
            int[] G = new int[n+1];
            G[0] = 1;
            G[1] = 1;
            for(int i=2; i<=n; i++)
            {
                for(int j=1; j<=i; j++)
                {
                    G[i]+=G[j-1]*G[i-j];
                }
            }

            return G[n];
        }
    }
}