using System;
using Sample.Tree;


namespace Sample
{
    public class FindCousin
    {
        public static FindCousin Instance = new FindCousin();
        private TreeNode Root;

        public void Do()
        {
            Read();
            Console.WriteLine(IsCousin(Root, 4, 5).ToString());
        }

        private void Read()
        {
            Root = new TreeNode(1);
            Root.left = new TreeNode(2);
            Root.right = new TreeNode(3);

            Root.left.right = new TreeNode(4);
            Root.right.right = new TreeNode(5);
        }

        private bool IsCousin(TreeNode root, int x, int y)
        {
            int l1 = FindLevel(root, x, 0);
            int l2 = FindLevel(root, y, 0);
            if(l1 == l2)
            {
                TreeNode n1 = FindNode(root, x);
                TreeNode n2 = FindNode(root, y);

                if(n1 != null && n2 != null)
                    return !IsSibling(root, n1, n2);
            }

            return false;
        }

        private bool IsCousins(TreeNode root, int x, int y)
        {
            System.Collections.Generic.Queue<TreeNode> queue = new System.Collections.Generic.Queue<TreeNode>();

            queue.Enqueue(root);

            while(queue.Count > 0)
            {
                bool iscousins = false;
                bool issiblings = false;

                int nodeAtDepth = queue.Count;

                for(int i =0; i<queue.Count; i++)
                {
                    TreeNode node = queue.Dequeue();

                    if(node == null)
                    issiblings = false;
                    else
                    {
                        if(node.val == x || node.val == y)
                        {
                            if(!iscousins)
                                iscousins = issiblings = true;
                            else
                            {
                                return !issiblings;
                            }
                        }

                        if(root.left != null) queue.Enqueue(root.left);
                        if(root.right != null) queue.Enqueue(root.right);

                        queue.Enqueue(null);
                    }
                }

                if(iscousins) return false;
            }

            return false;
        }

        private int FindLevel(TreeNode root, int data, int level)
        {
            if(root == null)
                return -1;

            if(root.val == data)
                return level;

            int ls = FindLevel(root.left, data, level+1);
            if(ls != -1)
                return ls;

            int rs = FindLevel(root.right, data, level+1);
            if(rs != -1)
                return rs;

            return -1;
        }

        private bool IsSibling(TreeNode root, TreeNode x, TreeNode y)
        {
            if(root == null) 
            return false;
            
            return (root.left == x && root.right == y) || (root.left == y && root.right == x) || IsSibling(root.left, x,y) || IsSibling(root.right, x, y);
        }

        private TreeNode FindNode(TreeNode root, int val)
        {
            if(root == null)
                return null;
            
            if(root.val == val)
                return root;
            
            TreeNode node = FindNode(root.left, val);
            if(node!=null)
                return node;

            node = FindNode(root.right, val);
            if(node != null)
                return node;
            
            return null;
        }
    }
}
