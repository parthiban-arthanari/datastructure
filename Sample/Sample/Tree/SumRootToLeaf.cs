using System;

namespace Sample.Tree
{
    public class SumRootToLeaf
    {
        public static SumRootToLeaf Instance = new SumRootToLeaf();

        TreeNode Root;
        private void Read()
        {
            Root = new TreeNode(4);

            TreeNode nine = new TreeNode(9);
            TreeNode five = new TreeNode(5);
            TreeNode one = new TreeNode(1);
            TreeNode zero = new TreeNode(0);
            TreeNode three = new TreeNode(3);
            TreeNode six = new TreeNode(6);
            TreeNode two = new TreeNode(2);

            three.left = two;
            three.right = six;

            zero.right = three;

            nine.left = five;
            nine.right = one;

            Root.left = nine;
            Root.right = zero;
        }

        public void Do()
        {
            Read();
            int val = SumNumbers(Root, 0);
        }

        private int SumNumbers(TreeNode root, int parent)
        {
            if(root == null) return -1;
            int temp = parent * 10 + root.val;
            int result;
            int l = SumNumbers(root.left, temp);
            result = l > 0 ? l : temp;
            int r = SumNumbers(root.right, temp);
            result = r > 0 ? r : temp;

            return Math.Max(l+r, result);
        }

        
    }
}