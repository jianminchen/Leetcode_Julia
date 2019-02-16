using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_longest_univalue_path___count_node
{    
    // Definition for a binary tree node.
    public class TreeNode {
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

        public static int longestPath = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int LongestUnivaluePath(TreeNode root)
        {
            longestPath = 0;
            postOrderTraversal(root);

            return longestPath;
        }

        /// <summary>
        /// count node
        ///     5
        ///   /   \
        ///  5     5
        ///  Write a story how to count node using the above test case. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int postOrderTraversal(TreeNode root)
        {
            if (root == null)
                return 0;

            var left  = postOrderTraversal(root.left);
            var right = postOrderTraversal(root.right);

            var crossPath = 0;

            var leftPath = 0;
            if (root.left != null && root.val == root.left.val)
            {
                leftPath = left;
                crossPath = left; 
            }

            var rightPath = 0;
            if (root.right != null && root.val == root.right.val)
            {
                rightPath = right;
                crossPath += right; 
            }

            longestPath = Math.Max(longestPath, crossPath); 

            return Math.Max(leftPath, rightPath) + 1;
        }
    }
}
