using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class PopulateNextPtr
    {
        public static PopulateNextPtr Instance = new PopulateNextPtr();

        public void Do()
        {

        }

        public void Connect(TreeNode root)
        {
            TreeNode prev = null;
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            queue.Enqueue(null);

            while(queue.Count > 0)
            {
                TreeNode node = queue.Dequeue();
                
                if(node != null)
                {
                    if(node.left != null) queue.Enqueue(node.left);
                    if(node.right != null) queue.Enqueue(node.right);
                }
                else if(queue.Count > 0)
                    queue.Enqueue(node);

                if(prev != null)
                    //prev.next = node;
                
                prev = node;
            }
        }
    }
}