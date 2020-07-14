using System;

namespace Sample.Tree
{
    public class Identical
    {
        public static Identical Instance = new Identical();

        private void Read()
        {

        }

        public void Do()
        {

        }

        private bool IsIdentical(TreeNode p, TreeNode q)
        {
            return (p != null && q != null && p.val == q.val && IsIdentical(p.left, q.left) && IsIdentical(p.right, q.right)) || (p == null && q == null);
        }
    }
}