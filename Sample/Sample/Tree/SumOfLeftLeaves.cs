using System;
namespace Sample.Tree
{
    public class SumOfLeftLeaves
    {
        public static SumOfLeftLeaves Instance = new SumOfLeftLeaves();
        TreeNode Node;

        public void Do()
        {
            Read();

            Console.WriteLine("Sum of all left leaves: " + SumOfAllLeftLeaves(Node));
        }

        public int SumOfAllLeftLeaves(TreeNode root)
        {
            int sum = 0;

            if (root == null)
                return sum;

            if (root.left != null && root.left.left == null && root.left.right == null)
                sum +=root.left.val;
            

            sum += SumOfAllLeftLeaves(root.left);
            sum += SumOfAllLeftLeaves(root.right);

            return sum;
        }

        private void Read()
        {
            Node = new TreeNode(1);

            TreeNode n1 = new TreeNode(9);
            TreeNode n2 = new TreeNode(20);
            TreeNode n3 = new TreeNode(15);
            TreeNode n4 = new TreeNode(7);

            Node.left = n1;
            Node.right = n2;

            n2.right = n4;
            n2.left = n3;
        }
    }
}
