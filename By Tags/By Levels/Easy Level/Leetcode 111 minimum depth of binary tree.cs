using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_111_minimum_depth_of_binary_tree
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

        public static int minimumDepth = int.MaxValue;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            minimumDepth = int.MaxValue;

            preorderTraversal(root, 1);

            return minimumDepth;
        }

        private void preorderTraversal(TreeNode root, int depth)
        {
            if (root.left == null && root.right == null)
            {
                minimumDepth = depth < minimumDepth ? depth : minimumDepth;
                return;
            }

            // visit root node

            if (depth + 1 > minimumDepth)
                return;

            if (root.left != null)
                preorderTraversal(root.left, depth + 1);

            if (root.right != null)
                preorderTraversal(root.right, depth + 1);
        }
    }
}
