using System;

namespace Sample.Tree
{
    public class BSTFromPre
    {
        public static BSTFromPre Instance = new BSTFromPre();

        int[] arr;

        private void Read()
        {
            arr = Utility.ConvertArray<int>("[1,2,3]");
        }

        public void Do()
        {
            Read();
            int index = 0;
            var node = Build(arr, ref index, int.MinValue, int.MaxValue);
        }

        private TreeNode Build(int[] arr, ref int index, int lower, int upper)
        {
            if(index >= arr.Length)  return null;

            int val = arr[index];

            if(val < lower || val > upper) return null;

            index++;
            TreeNode node = new TreeNode(val);
            node.left = Build(arr, ref index, lower, val);
            node.right = Build(arr, ref index, val, upper);

            return node;
        }
    }
}