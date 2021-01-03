using System;

namespace Sample.Tree
{
    public class IsvalidBT
    {
        public static IsvalidBT Instance = new IsvalidBT();
        TreeNode Root;
        int low;
        int high;

        private void Read()
        {
            TreeNode n1 = new TreeNode(5);
            TreeNode n2 = new TreeNode(4);
            TreeNode n3 = new TreeNode(6);
            TreeNode n4 = new TreeNode(3);
            TreeNode n5 = new TreeNode(7);

            n1.left = n2;
            n1.right = n3;
            n3.left = n4;
            n3.right = n5;

            Root = n1;
        }

        public void Do()
        {
            Read();
            var val = IsValid(Root);
        }

        private bool IsValid(TreeNode root)
        {
           return validate(root, null, null);
        }

        private bool validate(TreeNode root, int? low, int? high)
        {
            if(root == null)
                return true;
            
            if((low != null && root.val <= low) || (high != null && root.val >= high))
                return false;
            
            return validate(root.left, low, root.val) && validate(root.right, root.val, high);
        }
    }
}