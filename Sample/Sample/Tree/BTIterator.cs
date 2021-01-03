using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class BTIterator
    {
        public static BTIterator Instance = new BTIterator();
        TreeNode root;
        Stack<TreeNode> st = new Stack<TreeNode>();

        private void Read()
        {
            root = new TreeNode(7);

            TreeNode n1 = new TreeNode(3);
            TreeNode n2 = new TreeNode(15);
            TreeNode n3 = new TreeNode(9);
            TreeNode n4 = new TreeNode(20);

            root.left = n1;
            root.right = n2;

            n2.left = n3;
            n2.right = n4;

            PopulateStack(root);

        }

        public void Do()
        {
            Read();

            int val = Next();
            val = Next();
        }

        public int Next() 
        {
            int val = -1;
            if(HasNext())
            {
                TreeNode node = st.Pop();
                val = node.val;
                
                PopulateStack(node.right);

                // else if(node.right != null)
                //     st.Push(node.right);
            }
            return val;
        }
        
        public bool HasNext() 
        {
            return st.Count > 0;
        }
        
        private void PopulateStack(TreeNode node)
        {
            while(node != null)
            {
                st.Push(node);
                node = node.left;
            }
        }
    }
}