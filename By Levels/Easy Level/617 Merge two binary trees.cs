using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_617_Merge_Two_binary_trees
{
    /// <summary>
    /// Leetcode 617 
    /// 
    /// </summary>
    class Program
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
        }

        public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
        {
            if (t1 == null && t2 == null)
                return null;

            if (t1 == null)
                return t2;
            if (t2 == null)
                return t1;

            t1.val = t1.val + t2.val;

            t1.left = MergeTrees(t1.left,  t2.left);
            t1.right = MergeTrees(t1.right, t2.right);

            return t1; 
        }
    }
}
