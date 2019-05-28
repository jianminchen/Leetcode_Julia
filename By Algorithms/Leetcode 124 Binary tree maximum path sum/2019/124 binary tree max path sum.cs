using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124_binary_tree_maximum_path_sum
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
            var node = new TreeNode(-3);
            var result = MaxPathSum(node);
        }

        public static int MaxCrossPath = Int32.MinValue; 
        /// <summary>
        /// 124. Binary tree maximum path sum 
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int MaxPathSum(TreeNode root)
        {
            MaxCrossPath = Int32.MinValue;
            maxPathFromRootToLeft(root);
            return MaxCrossPath;
        }

        /// <summary>
        /// max path from root node to leaf node
        /// post order traversal
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int maxPathFromRootToLeft(TreeNode root)
        {
            if (root == null)
                return 0;

            // post order traversal 
            var left  = maxPathFromRootToLeft(root.left);
            var right = maxPathFromRootToLeft(root.right);

            // root node 
            var value = root.val;

            var leftMax  = left  > 0 ? (left  + value)  : value;
            var rightMax = right > 0 ? (right + value)  : value;

            // extra task 
            var currentCross = value;
            if (left > 0)
            {
                currentCross += left;
            }

            if (right > 0)
            {
                currentCross += right;
            }

            MaxCrossPath = currentCross > MaxCrossPath ? currentCross : MaxCrossPath;
            // end of extra task 

            return Math.Max(leftMax, rightMax);
        }
    }
}
