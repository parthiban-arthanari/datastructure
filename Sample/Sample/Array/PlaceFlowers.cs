using System;

namespace Sample.Array
{
    public class PlaceFlowers
    {
        public static PlaceFlowers Instance = new PlaceFlowers();
        int[] flowerbed;
        int n;
        private void Read()
        {
            flowerbed = Utility.ConvertArray<int>("[0,0,0,0,0,1,0,0]");
            n = 0;
        }

        public void Do()
        {
            Read();
            var val = CanPlace(flowerbed, n);
        }

        private bool CanPlace(int[] flowerbed, int n)
        {
            int prev = 0;
            int next = 0;

            for(int i=0; i<flowerbed.Length; i++)
            {
                if(i<flowerbed.Length -1)
                    next = flowerbed[i+1];
                
                if(flowerbed[i] == 0)
                {
                    if(prev == 0 && next == 0)
                    {
                        flowerbed[i] = 1;
                        n--;
                    }

                    
                }

                if(n<=0)
                        return true;

                prev = flowerbed[i];
            }

            return false;
        }
    }
}