using System;
using System.Collections.Generic;

namespace Sample.Array
{
    public class KSum
    {
        public static KSum Instance = new KSum();
        List<Tuple<int,int, int>> triplet = new List<Tuple<int, int, int>>();

        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[1,0,-1,0,-2,2]");
        }

        public void Do()
        {
            Read();
            var val = KSumCount();
        }

        private List<List<int>> TwoSum(int[] arr, int target, int start)
        {
            List<List<int>> res = new List<List<int>>();
            int n = arr.Length;
            int lo = start;
            int hi = n - 1;

            while(lo < hi)
            {
                int sum = arr[lo] + arr[hi];
                if(target > sum || (lo > start && arr[lo] == arr[lo-1]))
                    lo++;
                else if(sum > target || (hi < n-1 && arr[hi] == arr[hi+1]))
                    hi--;
                else
                {
                    res.Add(new List<int>{arr[lo++], arr[hi--]});
                }
            }
            return res;
        }

        private void ThreeSum()
        {
            int n = arr.Length;
            System.Array.Sort(arr);
            for(int i= 0; i<n && arr[i] <=0; i++)
            {
                TwoSum(arr, -arr[i], i+1);
            }
        }

        private void ThreeSum_NoSort()
        {
            int n = arr.Length;
            List<System.Array> triple = new List<System.Array>();
            HashSet<int> dups = new HashSet<int>();
            Dictionary<int, int> seen = new Dictionary<int, int>();

            for(int i=0; i<n; i++)
            {
                if(dups.Add(arr[i]))
                {
                    for(int j=i+1; j<n; j++)
                    {
                        int complement = -arr[i]-arr[j];
                        if(seen.ContainsKey(complement) && seen[complement] == i)
                        {
                            System.Array temp = new int[] {arr[i], arr[j], complement};
                            System.Array.Sort(temp);
                            triple.Add(temp);
                        }
                        seen[arr[j]] = i;
                    }
                }
            }
        }

        private List<List<int>> FindKSum(int[] arr, int target, int start, int k)
        {
            List<List<int>> res = new List<List<int>>();
            int n = arr.Length;
            if(start == n-1 || arr[start]*k > target || target > arr[n-1]*k)
                return res;
            if(k==2)
                return TwoSum(arr, target, start);
            for(int i= start; i<n; i++)
                if(i==start || arr[i]!=arr[i-1])
                    foreach(var r in FindKSum(arr, target - arr[i], i+1, k-1))
                    {
                        res.Add(new List<int>(){arr[i]});
                        res[res.Count - 1].AddRange(r);
                    }
            return res;
        }

        private List<List<int>> FourSum(int[] arr, int target)
        {
            System.Array.Sort(arr);
            return FindKSum(arr, target, 0, 4);
        }

        private int FourSumCount(int[] A, int[] B, int[] C, int[]D)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            int count = 0;
            foreach(var a in A)
                foreach(var b in B)
                    if(map.ContainsKey(a+b))
                        map[a+b] += 1;
                    else
                        map[a+b] = 1;
                    
            foreach(var c in C)
                foreach(var d in D)
                    if(map.ContainsKey(-(c+d)))
                        count += map[-(c+d)];
        
            return count;
        }

        public int KSumCount()
        {
            int[] a = {1, 2};
            int[] b = {-2,-1};
            int[] c = {-1,2};
            int[] d = {0,2};
            int[] e = {-1,2};
            int[] f = {-2,0};
            return KSumCount(new int[][]{a,b,c,d,e,f});
        }

        public int KSumCount(int[][] lists)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            AddToHash(lists, map, 0, 0);
            return Compliements(lists, map, lists.Length/2, 0);
        }

        private void AddToHash(int[][] lists, Dictionary<int, int> map, int i, int sum)
        {
            if(i==lists.Length / 2)
                if(map.ContainsKey(sum))
                    map[sum] +=1;
                else
                    map[sum] = 1;
            else
                foreach(int a in lists[i])
                    AddToHash(lists, map, i+1, sum+a);
        }

        private int Compliements(int[][] lists, Dictionary<int, int> map, int i, int complement)
        {
            if(i==lists.Length)
                return map.ContainsKey(complement) ? map[complement] : 0;
            int count = 0;
            foreach(int a in lists[i])
                count += Compliements(lists, map, i+1, complement -a);
            return count;
        }


    }
}