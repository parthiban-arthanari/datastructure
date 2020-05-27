using System;
using Sample.Tree;

namespace Sample.DayChallenge
{
    public class DiameterOfTree
    {
        public static DiameterOfTree Instance = new DiameterOfTree();
        TreeNode root;
        int diameter = 0;

        private void Read()
        {
            TreeNode n1 = new TreeNode(1);
            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);
            TreeNode n8 = new TreeNode(8);
            TreeNode n9 = new TreeNode(9);
            TreeNode n10 = new TreeNode(10);
            TreeNode n11 = new TreeNode(11);
            TreeNode n12 = new TreeNode(12);
            TreeNode n13 = new TreeNode(13);
            TreeNode n14 = new TreeNode(14);
            //TreeNode n15 = new TreeNode(15);
            //TreeNode n16 = new TreeNode(16);
            //TreeNode n17 = new TreeNode(17);
            //TreeNode n18 = new TreeNode(18);

            root = n1;
            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            n5.left = n6;

            n6.left = n7;

            n4.left = n8;

            n8.left = n9;

            //n7.left = n8;

            //n8.left = n14;

            //n7.right = n9;

            //n9.right = n10;

            //n10.right = n11;

            //n11.right = n12;

            //n12.right = n13;       
        }

        public void Do()
        {
            Read();
            FindDiameter(root);
            //FindDepth(root);
            Console.WriteLine("Diamter of Tree - {0}", diameter);
        }

        private int FindDiameter(TreeNode root)
        {
            if (root == null)
                return 0;

            int left = FindDiameter(root.left);
            int right = FindDiameter(root.right);

            if (root.left != null)
                left = left + 1;

            if (root.right != null)
                right = right + 1;

            diameter = Math.Max(left + right, diameter);

            return Math.Max(left, right);
        }

        private int FindDepth(TreeNode root)
        {
            if (root == null) return 0;

            int left = FindDepth(root.left);
            int right = FindDepth(root.right);

            diameter = Math.Max(left + right + 1, diameter);

            return Math.Max(left, right) + 1;
        }
    }
}
