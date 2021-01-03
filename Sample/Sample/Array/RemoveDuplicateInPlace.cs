using System;

namespace Sample.Array
{
    public class RemoveDuplicateInPlace
    {
        public static RemoveDuplicateInPlace Instance = new RemoveDuplicateInPlace();

        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[1,1,1,1,1,1,2,3,3,4,4,4,4,5]");
        }

        public void Do()
        {
            Read();
            var val = RemoveDuplicate(arr);
        }

        private int RemoveDuplicate(int[] arr)
        {
           int count = 1;
           int j =1;
           int n = arr.Length;

           for(int i=1; i<n; i++)
           {
               if(arr[i-1] == arr[i])
                    count++;
                else
                    count = 1;   

                if(count <= 2)
                    arr[j++] = arr[i];                    
            }
        return j < n ? j : n;
        }
    }
}