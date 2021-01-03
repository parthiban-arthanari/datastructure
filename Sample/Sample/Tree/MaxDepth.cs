using System;
using System.Collections.Generic;

namespace Sample.Tree 
{
    public class MaxDepth
    {
        public static MaxDepth Instance = new MaxDepth();

        TreeNode _root;
        Dictionary<int, int> levels = new Dictionary<int, int>();

        int maxDepth;

        private void Read()
        {
            _root = new TreeNode(1);

            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);
            TreeNode n8 = new TreeNode(8);
            TreeNode n9 = new TreeNode(9);

            _root.left = n2;
            _root.right = n3;

            n2.left = n4;
            // n2.right = n5;

            // n3.left = n6;
            // n3.right = n7;

            n4.left = n8;
            n7.right = n9;
        }

        public void Do()
        {
            Read();
            MaxDpeth(_root, 1);
            var val = maxDepth;
        }

        public void MaxDpeth(TreeNode root, int level)
        {
            if(root == null)
                return;

            maxDepth = Math.Max(maxDepth, level);
            MaxDpeth(root.left, level+1);
            MaxDpeth(root.right, level+1);
        }
    }
}