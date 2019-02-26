using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest__univalue_path
{
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

        public static int maxCrossPath = int.MaxValue; 
        public static int LongestUnivaluePath(TreeNode root)
        {
            if (root == null)
                return 0;

            maxCrossPath = 0;
            postOrderTraversal(root);

            return maxCrossPath;
        }

        /// <summary>
        /// recursive return: longest univalue path from root to leaf
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int postOrderTraversal(TreeNode root)
        {
            if (root == null)
                return 0;

            var left = postOrderTraversal(root.left);
            var right = postOrderTraversal(root.right);

            // root node 
            var value = root.val;
            var leftMax = 1;
            var crossPath = 0;
            if (root.left != null && value == root.left.val)
            {
                leftMax = 1 + left; // count node
                crossPath += left;
            }

            var rightMax = 1;
            if (root.right != null && value == root.right.val)
            {
                rightMax = 1 + right;
                crossPath += right;
            }

            maxCrossPath = Math.Max(maxCrossPath, crossPath);

            return Math.Max(leftMax, rightMax);
        }
    }
}
