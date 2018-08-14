using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_404_sum_of_left_leaves
{
    /// <summary>
    /// Leetcode 404 - sum of left leaves
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
        /// test case: 
        /// empty node, tree with one left node. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int SumOfLeftLeaves(TreeNode root)
        {
            if (root == null)
                return 0;

            var leftLeaves = 0;
            if (root.left != null)
            {
                if (root.left.left == null && root.left.right == null)
                    leftLeaves += root.left.val;
            }

            return leftLeaves + SumOfLeftLeaves(root.left) + SumOfLeftLeaves(root.right);
        }
    }
}