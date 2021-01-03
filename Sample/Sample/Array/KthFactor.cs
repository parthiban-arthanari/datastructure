using System;

namespace Sample.Array
{
    public class KthFactor
    {
        public static KthFactor Instance = new KthFactor();
        int n, k;

        private void Read()
        {
            n = 12;
            k =3;
        }

        public void Do()
        {
            Read();
            var val = GetFactor(n,k);
        }

        private int GetFactor(int n, int k)
        {
            for(int i=1; i<=n; i++)
            {
                if(n%i == 0)
                {
                    k--;
                    if(k==0)
                        return i;
                }
            } 

            return -1;
        }
        
    }
}