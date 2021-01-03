using System;
using System.Collections.Generic;

namespace Sample.Tree
{
    public class PseudoPolindromicPath
    {
        public static PseudoPolindromicPath Instance = new PseudoPolindromicPath();

        TreeNode Root;

        private void Read()
        {
            TreeNode n1 = new TreeNode(2);
            TreeNode n2 = new TreeNode(3);
            TreeNode n3 = new TreeNode(1);

            TreeNode n4 = new TreeNode(3);
            TreeNode n5 = new TreeNode(1);
            TreeNode n6 = new TreeNode(1);

            n1.left = n2;
            n1.right = n3;

            n2.left = n4;
            n2.right = n5;

            n3.right = n6;

            Root = n1;
        }

        public void Do()
        {
            Read();
            HashSet<int> h = new HashSet<int>();
            var val =  IsPolindromicPath(Root, h);
        }

        int IsPolindromicPath(TreeNode Root, HashSet<int> hash)
        {
            int count = 0;

            if(Root != null)
            {

            UpdateDict(hash, Root.val);

            if(Root.left == null && Root.right == null)
            {
                if(hash.Count <= 1)
                    count++;
            }
            count += IsPolindromicPath(Root.left, hash);
            count += IsPolindromicPath(Root.right, hash);

            UpdateDict(hash, Root.val);
            }

            return count;
        }

        private void UpdateDict(HashSet<int> hash, int val)
        {
            if(hash.Contains(val))
                hash.Remove(val);
            else
                hash.Add(val);
        }
    
    }
}