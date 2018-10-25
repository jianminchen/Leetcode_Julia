using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode687_longest_univalue_path___study_code_1
{
    class Program
    {
        /// <summary>
        /// Leetcode 687
        /// study code from
        /// https://leetcode.com/problems/longest-univalue-path/discuss/108175/java-solution-with-global-variable
        /// </summary>
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

        int maxLength = 0; // global variable
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null) return 0;
            maxLength = 0;
            getLen(root, root.val);
            return maxLength;
        }

        /// <summary>
        /// design a recursive function as simple as possible
        /// using preorder traversal to traverse the binary tree, and also calculate
        /// the maximum path from root to leaf path with the same value. 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        private int getLen(TreeNode node, int val)
        {
            if (node == null)
            {
                return 0;
            }

            var current = node.val;

            int left  = getLen(node.left,  current);
            int right = getLen(node.right, current);

            maxLength = Math.Max(maxLength, left + right); // longest univalue path crossing the root

            if (val == current)
            {
                return Math.Max(left, right) + 1; 
            }

            return 0;
        }
    }
}
