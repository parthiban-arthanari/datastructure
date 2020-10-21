using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class NumSmallerAfterItSelf
    {
        public static NumSmallerAfterItSelf Instance = new NumSmallerAfterItSelf();

        int[] nums;
        int[] seg;
        int[] a;
        int max_i;
        int max_k;

        private void Read()
        {
            nums = Utility.ConvertArray<int>("[101,99,96,1]");
        }

        public void Do()
        {
            Read();
            var val = CountSmaller_BTree(nums);
        }

        private IList<int> CountSmaller(int[] nums)
        {
            int n = nums.Length;
            int[] ans = new int[n];
            int max = int.MinValue;
            for(int i=0; i<n; i++)
                max = Math.Max(max, nums[i]);
            seg = new int[max*5];
            a = new int[max+1];
            for(int i = n-1; i>=0; i--)
            {
                ans[i] = Sum(0, 2*max+1, 0, 0, nums[i]-1);
                a[nums[i]]++;
                Update(0, 2*max+1, 0, nums[i]);
            }

            return ans;
        }

        void Update(int l, int r, int i, int k)
        {
            max_i = Math.Max(max_i, i);
            max_k = Math.Max(max_k, k);
            if(k < l || k > r)
                return;
            if(l == r)
                seg[i] = a[k];
            else
            {
                int mid = (l+r) / 2;
                Update(l, mid, i * 2 + 1, k);
                Update(mid + 1, r, i * 2 + 2, k);
                seg[i] = seg[i*2+1] + seg[i*2+2];
            }
        }

        int Sum(int l, int r, int i, int L, int R)
        {
            if(R < l || L > r)
                return 0;
            if(l >= L && r <= R)
                return seg[i];
            int mid = (l + r) / 2;
            return Sum(l, mid, i*2+1,L, R) + Sum(mid + 1, r, i*2+2, L, R);
        }

        private IList<int> CountSmaller_BTree(int[] arr)
        {
            List<int> res = new List<int>();

            if(arr.Length == 0 || arr.Length == 1)
                return res;
            
            BTree root = new BTree(arr[arr.Length -1]);
            res.Add(0);

            for(int i=arr.Length-2; i>=0; i--)
            {
                int count = Add(root, arr[i]);
                res.Add(count);
            }

            res.Reverse();
            return res;
        }

        private int Add(BTree root, int val)
        {
            int Count = 0;
            while(true)
            {
                if(val <= root.val)
                {
                    root.Count++;
                    if(root.left == null)
                    {
                        root.left = new BTree(val); 
                        break;
                    }
                    else
                        root = (BTree)root.left;
                }
                else
                {
                    Count += root.Count;
                    if(root.right == null)
                    {
                        root.right = new BTree(val);
                        break;
                    }
                    else
                        root = (BTree)root.right;
                }
            }
            return Count;
        }
    }

    public class BTree : TreeNode
    {
        public int Count;

        public BTree(int val) : base(val)
        {this.Count = 1;}
    }
}