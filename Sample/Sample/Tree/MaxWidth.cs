using System;
using System.Collections.Generic;

namespace Sample.Tree 
{
    public class MaxWidth
    {
        public static MaxWidth Instance = new MaxWidth();

        TreeNode _root;
        Dictionary<int, int> levels = new Dictionary<int, int>();

        int maxWidth;

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
            var val = FindWidth(_root);
        }

        private int FindWidth(TreeNode root)
        {
            if(root == null)
                return 0;
            Queue<Tuple<TreeNode, int>> queue = new Queue<Tuple<TreeNode, int>>();
            int width =0;
            queue.Enqueue(new Tuple<TreeNode, int>(root, 0));

            while(queue.Count > 0)
            {
                var head = queue.Peek();
                var size = queue.Count;
                Tuple<TreeNode, int> ele = null;
                for(int i=0; i< size; i++)
                {
                    ele = queue.Dequeue();
                    var node = ele.Item1;
                    if(node.left != null) queue.Enqueue(new Tuple<TreeNode, int>(node.left, 2*ele.Item2));
                    if(node.right != null) queue.Enqueue(new Tuple<TreeNode, int>(node.right, 2*ele.Item2 +1));
                }

                width = Math.Max(width, ele.Item2 - head.Item2 + 1);
            }

            return width;
        }

        public void WidthByDFS(TreeNode root, int level, int index) 
        {
            if (root == null)
                return;

            if(!levels.ContainsKey(level))
                levels.Add(level, index);
            
            int firstIndex = levels[level];

            maxWidth = Math.Max(maxWidth, index - firstIndex + 1);

            WidthByDFS(root.left, level +1, 2*index);
            WidthByDFS(root.right, level+1, 2*index +1);
        }
    }
}