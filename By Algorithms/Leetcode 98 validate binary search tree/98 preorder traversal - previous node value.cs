using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98_validate_BST___preorder
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

        public static long previous = long.MinValue;

        /// <summary>
        /// code review July 16, 2019
        /// preorder traversal - only care about previous node's value
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsValidBST(TreeNode root)
        {
            previous = long.MinValue; // caught by online judge
            return runPreorderTraversal(root);
        }

        private static bool runPreorderTraversal(TreeNode root)
        {
            if (root == null)
                return true;

            var left = runPreorderTraversal(root.left);

            // root node
            if (root.val <= previous)
                return false;

            previous = root.val;

            var right = runPreorderTraversal(root.right);

            return left && right;
        }
    }
}
