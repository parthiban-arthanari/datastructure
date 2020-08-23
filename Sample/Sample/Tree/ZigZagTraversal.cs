using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class ZigZagTraversal
    {
        public static ZigZagTraversal Instance = new ZigZagTraversal();

        TreeNode Root;

        private void Read()
        {
            Root = new TreeNode(1);

            TreeNode n2 = new TreeNode(2);
            TreeNode n3 = new TreeNode(3);
            TreeNode n4 = new TreeNode(4);
            TreeNode n5 = new TreeNode(5);
            TreeNode n6 = new TreeNode(6);
            TreeNode n7 = new TreeNode(7);

            Root.left = n2;
            Root.right = n3;

            n2.left = n4;
            n2.right = n5;

            n3.left = n6;
            n3.right = n7;
        }

        public void Do()
        {
            Read();
            var val = Traverse(Root);
        }

        private IList<IList<int>> Traverse(TreeNode root)
        {
            Stack<TreeNode> s1 = new Stack<TreeNode>();
            Stack<TreeNode> s2 = new Stack<TreeNode>();
            IList<IList<int>> list = new List<IList<int>>();
            IList<int> list1 = new List<int>();
            int flag = 0;

            if(root != null)
            {
                s1.Push(root);

                while(s1.Count > 0)
                {
                    var node = s1.Pop();

                    if(flag == 0)
                    {
                        if(node.left != null) s2.Push(node.left);
                        if(node.right != null) s2.Push(node.right);
                    }
                    else
                    {
                        if(node.right != null) s2.Push(node.right);
                        if(node.left != null) s2.Push(node.left);
                    }
                    list1.Add(node.val);

                    if(s1.Count == 0)
                    {
                        var temp = s1;
                        s1 = s2;
                        s2 = temp;

                        flag ^=1;
                        list.Add(list1);
                        list1 = new List<int>();
                    }
                }
            }
            return list;
        }
    }
}