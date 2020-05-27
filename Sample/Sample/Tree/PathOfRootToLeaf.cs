using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class PathOfRootToLeaf
    {
        public static PathOfRootToLeaf Instance = new PathOfRootToLeaf();
        TreeNode Node;

        public void Do()
        {
            Read();

            IList<string> paths = BinaryTreePaths(Node);

            for(int i=0; i< paths.Count; i++)
            {
                Console.WriteLine(paths[i]);
            }
        }

        private void Read()
        {
            Node = new TreeNode(1);

            TreeNode two = new TreeNode(2);
            TreeNode three = new TreeNode(3);
            TreeNode five = new TreeNode(5);

            Node.left = two;
            Node.right = three;

            two.right = five;
        }

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            List<string> paths = new List<string>();
            string path = string.Empty;
            Paths(root, path, paths);
            return paths;

        }

        public void Paths(TreeNode root, string parent, IList<string> paths)
        {
            if (root == null)
                return;

            string temp;
            if (string.IsNullOrEmpty(parent))
            {
                temp = root.val.ToString();
            }
            else
            {
                temp = parent + "->" + root.val.ToString();
            }

            if (root.left == null && root.right == null)
            {
                
                paths.Add(temp);
            }
            else
            {
                Paths(root.left, temp, paths);
                Paths(root.right, temp, paths);
            }
        }
    }
}
