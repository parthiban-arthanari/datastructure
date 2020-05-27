using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class KSmallest
    {
        public static KSmallest Instance = new KSmallest();
        TreeNode _root;
        int k;

        public void Do()
        {
            Read();

            List<int> _list = new List<int>();
            Inorder(_root, _list);

            Console.WriteLine("K- Smallest - {0}", _list[k]);

        }

        private void Inorder(TreeNode root, List<int> list)
        {
            if(root != null)
            {
                Inorder(root.left, list);
                list.Add(root.val);
                Inorder(root.right, list);
            }
        }

        private void Read()
        {
            TreeNode one = new TreeNode(1);
            TreeNode two = new TreeNode(2);
            TreeNode three = new TreeNode(3);
            TreeNode four = new TreeNode(4);
            TreeNode five = new TreeNode(5);
            TreeNode six = new TreeNode(6);

            _root = five;

            _root.left = three;
            _root.right = six;

            three.left = two;
            three.right = four;

            two.left = one;

            k = 4;
        }
    }
}