using System;
namespace Sample.Tree
{
    public class SearchNode
    {
        public static SearchNode Instance = new SearchNode();
        TreeNode Root;

        private void Read()
        {
            Root = new TreeNode(1);
            Root.left = new TreeNode(2);
            Root.right = new TreeNode(3);

            Root.left.right = new TreeNode(4);
            Root.right.right = new TreeNode(5);
        }

        public void Do()
        {
            Read();
            // SearchBST(Root, 4);
            int c = Count(Root);
        }

        private TreeNode SearchBST(TreeNode root, int val)
        {
            if(root == null) return null;

            if(root.val == val)
                return root;
            
            return SearchBST(root.left, val)?? SearchBST(root.right, val);
        }

        private int Count(TreeNode root)
        {
            if(root == null) return 0;

            int c = 0;
            c += Count(root.left);
            c += Count(root.right);

            return c+1;
        }
    }
}