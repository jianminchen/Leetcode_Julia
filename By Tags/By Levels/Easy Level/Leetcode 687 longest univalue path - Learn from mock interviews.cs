using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_longest_univalue_path
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

        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null)
                return 0;

            int longestPathCrossRoot = 0;
            getLongestPath(root, ref longestPathCrossRoot);

            return longestPathCrossRoot;
        }

        /// <summary>
        /// based on assumption that root node is not null
        /// longest path is defined from root node to leaf node with 
        /// value of root node's value
        /// Inorder traversal is implemented in the search of longest path
        /// for each node as root node
        /// </summary>
        /// <param name="root"></param>
        private static int getLongestPath(TreeNode root, ref int longestPathCrossRoot)
        {
            if (root.left == null && root.right == null)
                return 0; 
            
            // inorder - left, root, right 
            var left  = 0;
            var right = 0;
            var currentMax = 0;
            var currentMaxCrossRoot = 0; 
            var rootVal = root.val;
            if (root.left != null)
            {
                left = getLongestPath(root.left, ref longestPathCrossRoot);
                if (rootVal == root.left.val)
                {
                    currentMax = left + 1;
                    currentMaxCrossRoot = left + 1; 
                }
            }

            // root - Need to calculate the maximum path cross the root

            if (root.right != null)
            {
                right = getLongestPath(root.right, ref longestPathCrossRoot);
                if (rootVal == root.right.val)
                {
                    currentMax = Math.Max(currentMax, right + 1);
                    currentMaxCrossRoot += right + 1; 
                }
            }

            longestPathCrossRoot = Math.Max(longestPathCrossRoot, currentMaxCrossRoot);
            return currentMax; 
        }
    }
}
