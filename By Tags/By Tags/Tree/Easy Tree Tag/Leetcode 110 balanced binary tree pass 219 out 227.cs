using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_110_balanced_binary_tree
{
    class Program
    {
        /// <summary>
        /// Leetcode 110 - only pass 87/227
        /// 1
        ///  \
        ///   2
        ///    \
        ///     3
        /// fail test case 
        /// 
        /// fail the case - length of path can be more than two values
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
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            node1.left = node2;

            var result = IsBalanced(node1); 
        }

        /// <summary>
        /// a binary tree in which the depth of the two subtrees of every node never differ by more than 1.
        /// all the paths from the root to leaf with two heights, one is maximum height, another one is 
        /// maximum height - 1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static bool IsBalanced(TreeNode root)
        {
            if (root == null)
                return true;

            var heights = new HashSet<int>();

            findAllPathHeights(root, heights, 0);

            int max = heights.Max();
            int min = heights.Min();

            if (max - min > 1)
                return false;

            return doNotMissChild(root, max, 0, false);
        }

        private static void findAllPathHeights(TreeNode root, HashSet<int> heights, int prefixCount)
        {
            prefixCount++;

            if (root.left == null && root.right == null)
            {
                heights.Add(prefixCount);
                return;
            }

            if (root.left != null)
                findAllPathHeights(root.left, heights, prefixCount);

            if (root.right != null)
                findAllPathHeights(root.right, heights, prefixCount);
        }

        private static bool doNotMissChild(TreeNode root, int max, int prefixCount, bool lastLevel)
        {
            prefixCount++;

            if (root == null ||(root.left == null && root.right == null))
            {
                return true;
            }

            if (prefixCount < max - 1 && (root.left == null || root.right == null))
                return false;

            return doNotMissChild(root.left,  max, prefixCount)   && 
                   doNotMissChild(root.right, max, prefixCount);
        }
    }
}
