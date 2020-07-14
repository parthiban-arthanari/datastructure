using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class ThreeSum
    {
        public static ThreeSum Instance = new ThreeSum();

        int[] _arr;

        private void Read()
        {
            // _arr = Utility.ConvertArray<int>("[-1, 0, 1, 2, -1, -4]");
            _arr = Utility.ConvertArray<int>("[1,2,-2,-1]");
        }

        public void Do()
        {
            Read();
            var val = GetCount(_arr);
        }

        private IList<IList<int>> GetCount(int[] nums)
        {
            int count = 0;
            HashSet<Tuple<int,int>> found = new HashSet<Tuple<int, int>>();
            IList<IList<int>> list = new List<IList<int>>();
            for(int i=0; i<nums.Length; i++)
            {
                HashSet<int> map = new HashSet<int>();
                    int a = nums[i];
                    for(int j=i+1; j<nums.Length; j++)
                    {
                        int b = nums[j];
                        int c = -(a + b);

                        if(map.Contains(c))
                        {
                            int v1 = Math.Min(a,Math.Min(b,c));
                            int v2 = Math.Max(a, Math.Max(b,c));
                            if(found.Add(new Tuple<int, int>(v1,v2)))
                                list.Add(new List<int>(){a,b,c});
                            count++;
                        }
                        else
                            map.Add(b);
                        
                }
            }

            return list;
        }
    }
}