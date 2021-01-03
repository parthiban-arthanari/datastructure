using System;

namespace Sample.Tree
{
    public class NearestRightNode
    {
        public static NearestRightNode Instance = new NearestRightNode();
        TreeNode Root;
        TreeNode node;
        int found = -1;

        private void Read()
        {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);

            Root = n1;
            n1.left = n2;
            n1.right = n3;

            n2.right = n4;
            n3.left = n5;
            n3.right = n6;
            node = n4;
        }

        public void Do()
        {
            Read();
            var val = FindNearest(Root, node);
        }

        private TreeNode FindNearest(TreeNode root, TreeNode node)
        {
            return NearestNode(root, node, 0);
        }

        private TreeNode NearestNode(TreeNode root, TreeNode node, int level)
        {
            TreeNode n = null;
            if(root != null)
            {
                if(found == level)
                    return root;
                
                if(node.val == root.val)
                    found = level;
                
                else if(found < 0 || found >= level)
                {
                    n = NearestNode(root.left, node, level+1);
                    if(n == null)
                        n = NearestNode(root.right, node, level+1);
                }
            }
            return n;
        }
    }
}