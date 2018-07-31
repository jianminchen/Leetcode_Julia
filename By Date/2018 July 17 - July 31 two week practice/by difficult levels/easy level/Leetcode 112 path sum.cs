using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_112_path_sum
{
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

        public static bool foundPath = false;
        /// <summary>
        /// traverse the tree using preorder
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int sum)
        {
            if(root == null)
            {
                return false; 
            }

            foundPath = false;

            preorderTraversal(root, sum);

            return foundPath;
        }

        /// <summary>
        /// leaf node should be the end of path
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        private static void preorderTraversal(TreeNode root, int sum)
        {
            // base case
            if(root.left == null && root.right == null)
            {
                if (root.val == sum)
                    foundPath = true;

                return;
            }

            var current = root.val;
            var residue = sum - current;

            if (root.left != null)
                preorderTraversal(root.left, residue);

            if (foundPath)
                return;

            if (root.right != null)
                preorderTraversal(root.right, residue);
        }
    }
}
