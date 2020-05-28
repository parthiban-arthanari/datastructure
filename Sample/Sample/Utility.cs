using System;

namespace Sample
{
    public static class Utility
    {
        public static T[][] Convert2DArray<T>(string input, int size)
        {
            var temp = input.Substring(0, input.Length -1).Split(',');

            int len1 = temp.Length / size;

            T[][] arr = new T[len1][];

            for(int i =0; i<len1; i++)
            {
                arr[i]= new T[size];
                for(int j=0; j<size; j++)
                {
                    var value = temp[ (i * 2) + j].Replace("[", string.Empty).Replace("]", string.Empty);
                    arr[i][j] = (T)Convert.ChangeType(value, typeof(T));
                }

            }

            return arr;
        }

        public static T[] ConvertArray<T>(string input)
        {
            var temp = input.Substring(0, input.Length -1).Split(',');

            int size = temp.Length;

            T[] arr = new T[size];

                for(int i=0; i<size; i++)
                {
                    var value = temp[i].Replace("[", string.Empty).Replace("]", string.Empty);
                    arr[i] = (T)Convert.ChangeType(value, typeof(T));
                }
                
            return arr;
        }
    }
}