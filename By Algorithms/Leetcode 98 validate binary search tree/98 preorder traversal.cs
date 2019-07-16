using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98_validate_BST
{
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
            var result = IsValidBST(new TreeNode(0));
        }

        public static TreeNode previous = null;
        public static bool IsValidBST(TreeNode root)
        {
            previous = null; // caught by online judge

            // Just use the inOrder traversal to solve the problem.
            return runPreorderTraversal(root);
        }

        /// <summary>
        /// if it is a binary search tree, then preorder traversale output should be in ascending order
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool runPreorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            
            var left = runPreorderTraversal(root.left);                       

            
            if (previous != null && root.val <= previous.val)
            {
                return false;
            }

            previous = root;
            
            var right = runPreorderTraversal(root.right);

            return left && right; 
        }
    }
}
