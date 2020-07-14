using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Array
{
    public class Subset
    {
        public static Subset Instance = new Subset();

        int[] _arr;
        int k;

        IList<IList<int>> output = new List<IList<int>>();
        

        private void Read()
        {
            _arr = Utility.ConvertArray<int>("[1,2,3]");
        }

        public void Do()
        {
            Read();
            // var val = GetSubsets(_arr);
            var val = GetSubset_Lexico(_arr);
        }

        private IList<IList<int>> GetSubsets(int[] nums)
        {
            output.Add(new List<int>());

            for(int i=0; i<nums.Length; i++)
            {
                IList<IList<int>> list = new List<IList<int>>();
                foreach(var item in output)
                {
                    var temp = new List<int>(item);
                    temp.Add(nums[i]);
                    list.Add(temp);
                }

                ((List<IList<int>>)output).AddRange(list);
            }

            return output;
        }

        private IList<IList<int>> GetSubset_BT(int[] nums)
        {
            for(k=0; k<=nums.Length; k++)
            {
                BackTrack(0, new List<int>(),nums);
            }
            return output;
        }

        private void BackTrack(int first, List<int> curr, int[] nums)
        {
            if(curr.Count == k)
                output.Add(new List<int>(curr));

            for(int i=first; i<nums.Length; i++)
            {
                curr.Add(nums[i]);
                BackTrack(i+1, curr, nums);
                curr.RemoveAt(curr.Count -1);
            }
        }

        private IList<IList<int>> GetSubset_Lexico(int[] nums)
        {
            int n = nums.Length;

            for(int i= (int)Math.Pow(2,n); i<(int)Math.Pow(2, n+1); i++)
            {
                string bitmask = Convert.ToString(i, 2).Substring(1);

                List<int> curr = new List<int>();

                for(int j=0; j<n; j++)
                {
                    if(bitmask[j] == '1') curr.Add(nums[j]);
                }

                output.Add(curr);
            }
            return output;
        }
    }
}