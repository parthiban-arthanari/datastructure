using System;

namespace Sample.Tree
{
    public class IsBalanced
    {
        public static IsBalanced Instance = new IsBalanced();

        TreeNode Root;

        private void Read()
        {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(2);
            TreeNode n4 = new TreeNode(3);
            TreeNode n5 = new TreeNode(3);
            TreeNode n6 = new TreeNode(4);
            TreeNode n7 = new TreeNode(4);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            n4.left = n6;
            n4.right = n7;

            Root = n1;
        }

        public void Do()
        {
            Read();
            // var val = GetHeight(Root) > 0 ? true : false;
            var val = IsBalanced1(Root);
        }
        private int GetHeight(TreeNode root)
        {
            if(root != null)
            {
                int left = GetHeight(root.left);
                if(left < 0)
                    return  left;
                int right = GetHeight(root.right);
                if(right < 0)
                    return right;
                if(Math.Abs(left-right) > 1)
                    return -1;
                return Math.Max(left, right) + 1;
            }
            return 0;
        }

        private int Height(TreeNode root)
        {
            if(root == null)
             return -1;
             return 1+Math.Max(Height(root.left), Height(root.right));
        }

        private bool IsBalanced1(TreeNode root)
        {
            if(root == null)
             return true;
            
            return Math.Abs(Height(root.left) - Height(root.right)) < 2 && IsBalanced1(root.left) && IsBalanced1(root.right);
        }
    }
}