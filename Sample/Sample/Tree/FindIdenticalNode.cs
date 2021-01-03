using System;

namespace Sample.Tree
{
    public class FindIdenticalNode
    {
        public static FindIdenticalNode Instance = new FindIdenticalNode();
        TreeNode Root;

        void Read()
        {

        }

        public void Do()
        {
            Read();
        }

        TreeNode Find(TreeNode original, TreeNode clone, TreeNode target, int i1, int i2)
        {
            if(original == null || clone == null)
                return null;

            if(original.val == target.val && clone.val == target.val && i1 == i2)
                return clone;
            
            TreeNode res = Find(original.left, clone.left, target, i1++, i2++);
            if(res != null)
                res = Find(original.right, clone.right, target, i1++, i2++);

            return res;
        }
    }
}
