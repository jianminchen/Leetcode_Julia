using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_110_balanced_binary_tree_Study_code
{
    class Program
    {
        /// <summary>
        /// Leetcode 110 - balanced binary tree 
        /// study code: 
        /// https://leetcode.com/problems/balanced-binary-tree/discuss/35691/The-bottom-up-O(N)-solution-would-be-better
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

        /// <summary>
        /// time complexity: 
        /// O(N^2), N is the number of nodes in the binary tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }

            int left  = depth(root.left);
            int right = depth(root.right);

            return Math.Abs(left - right) <= 1 && IsBalanced(root.left) && IsBalanced(root.right);
        }

        /// <summary>
        /// Time complexity:
        /// O(N * N) 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int depth(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            return Math.Max(depth(root.left), depth(root.right)) + 1;
        }
    }
}
