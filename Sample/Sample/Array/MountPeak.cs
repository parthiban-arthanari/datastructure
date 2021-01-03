using System;

namespace Sample.Array
{
    public class MountPeak
    {
        public static MountPeak Instance = new MountPeak();
        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[1,5,5]"); 
        }

        public void Do()
        {
            Read();
            var val = CheckPeak(arr);
        }

        private bool CheckPeak(int[] arr)
        {
            int n = arr.Length;  
            int i=0;  

            while(i+1<n && arr[i] < arr[i+1])
            i++;

            if(i==0 || i==n-1)
                return false;
            
            while(i+1 <n && arr[i] > arr[i+1])
            i++;
            
            return i==n-1;
        }
    }
}