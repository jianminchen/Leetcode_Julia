using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lowest_common_ancestor_235
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// code review May 7, 2019
        /// Leetcode 235: Lowest common ancestor
        /// Assumptions:
        /// 1. All of the nodes' values will be unique.
        /// 2. p and q are different and both values will exist in the BST.
        /// 
        /// Time complexity: O(logn), it is like a binary search, every time half of numbers are thrown away
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            var maxValue = Math.Max(p.val, q.val);
            var minValue = Math.Min(p.val, q.val);

            if (maxValue < root.val)
            {
                return LowestCommonAncestor(root.left, p, q);
            }

            if (minValue > root.val)
                return LowestCommonAncestor(root.right, p, q);           

            return root;
        }
    }
}
