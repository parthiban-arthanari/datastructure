using System;
using System.Collections;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class ReverseLevelOrder
    {
        public static ReverseLevelOrder Instance = new ReverseLevelOrder();

        TreeNode Root;

        private void Read()
        {
            TreeNode n3 = new TreeNode(3);

            TreeNode n9 = new TreeNode(9);
            TreeNode n20 = new TreeNode(20);

            TreeNode n15 = new TreeNode(15);
            TreeNode n7 = new TreeNode(7);

            Root = n3;

            n3.left = n9;
            n3.right = n20;

            n20.left = n15;
            n20.right = n7;

        }

        public void Do()
        {
            Read();
            var val = LevelOrderBottom(Root);
        }

        private IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            List<TreeNode> list = new List<TreeNode>();
            int level = 0;
            IList<IList<int>> ret = new List<IList<int>>(level);
            IList<int> l = new List<int>();

            if(root != null)
            {
                queue.Enqueue(root);
                queue.Enqueue(null);

                while(queue.Count > 0)
                {
                    var node = queue.Dequeue();
                    list.Add(node);
                    
                    if(node != null)
                    {
                        if(node.left != null) queue.Enqueue(node.left);
                        if(node.right != null) queue.Enqueue(node.right);
                    }
                    else if(queue.Count > 0)
                    {
                        queue.Enqueue(null);
                        level++;
                    }
                    
                }

                ret = new List<int>[level+1];
                
                ret[level] = l;
                for(int i=0; i<list.Count; i++)
                {
                    var node = list[i];

                    if(node != null)
                        l.Add(node.val);
                    else if(level > 0)
                    {
                        level--;
                        l = new List<int>();
                        ret[level] = l;
                    }
                }
            }

            return ret;
        }
    }
}