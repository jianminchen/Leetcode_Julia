using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_572_subtree_of_another_tree
{
    /// <summary>
    /// Leetcode 572 - subtree of another tree
    /// </summary>
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Time complexity: 
        /// I need to look into the time complexity here. 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;

            if (s == null || t == null)
                return false;

            if (s.val == t.val)
            {
                var sameTree = s.val == t.val && isSameTree(s.left, t.left) && isSameTree(s.right, t.right);
                if (sameTree)
                    return true;
            }
            
            return IsSubtree(s.left, t) || IsSubtree(s.right, t);
        }

        private bool isSameTree(TreeNode s, TreeNode t)
        {
            if (s == null && t == null)
                return true;

            if (s == null || t == null)
                return false;

            return s.val == t.val && isSameTree(s.left, t.left) && isSameTree(s.right, t.right);
        }
    }
}
