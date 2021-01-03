using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Sample
{
    public class ComparableArray : List<int>, IComparable<ComparableArray>
    {
        public ComparableArray(int[] arr)
        {
            this.AddRange(new List<int>(arr));
        }
        public int CompareTo(ComparableArray other)
        {
            return this[1] - other[1];
        }
    }

    public static class Utility
    {
        public static T[][] Convert2DArray<T>(string input, int col)
        {
            var temp = input.Substring(0, input.Length -1).Split(',');

            int len1 = temp.Length / col;

            T[][] arr = new T[len1][];

            for(int i =0; i<len1; i++)
            {
                arr[i]= new T[col];
                for(int j=0; j<col; j++)
                {
                    var value = temp[ (i * col) + j].Replace("[", string.Empty).Replace("]", string.Empty);
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
                    if(!value.Equals(string.Empty))
                        arr[i] = (T)Convert.ChangeType(value, typeof(T));
                }
                
            return arr;
        }
    }
}