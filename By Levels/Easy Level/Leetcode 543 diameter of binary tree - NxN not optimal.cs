using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_543_Dimaeter_of_binary_tree
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
            var root = new TreeNode(1);
            var result = DiameterOfBinaryTree(root); 
        }
        
        /// <summary>
        /// time complexity: 
        /// O(N), N is the number of nodes in the tree
        /// using preorder traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int DiameterOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;
            var current = getMaximumValuePath(root.left) + getMaximumValuePath(root.right);

            return Math.Max(current, Math.Max(DiameterOfBinaryTree(root.left), DiameterOfBinaryTree(root.right)));
        }

        private static int getMaximumValuePath(TreeNode root)
        {
            if (root == null)
                return 0;

            var left = getMaximumValuePath(root.left);
            var right = getMaximumValuePath(root.right);

            return 1 + Math.Max(left,
                right);
        }
    }
}
