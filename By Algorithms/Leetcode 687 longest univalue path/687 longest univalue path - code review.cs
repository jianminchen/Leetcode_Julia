using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_univalue_path___code_study
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
            var node1 = new TreeNode(1);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node4B = new TreeNode(4);
            var node4C = new TreeNode(4);
            var node5B = new TreeNode(5);

            node1.left = node4;
            node1.right = node5;

            node4.left = node4B;
            node4.right = node4C;

            node5.left = node5B;

            LongestUnivaluePath(node1);
        }
        
        /// <summary>
        /// code review on the longest univalue path by a casual coder
        /// http://anothercasualcoder.blogspot.com/2018/12/largest-binary-search-tree-bst-by-apple.html
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int LongestUnivaluePath(TreeNode root)
        {
            int maxThruCurrent = 0;
            int maxCurrent = 0;

            LongestUnivaluePath(root, ref maxThruCurrent, ref maxCurrent);
            return maxThruCurrent;
        }

        private static void LongestUnivaluePath(TreeNode root,
            ref int maxThruCurrent,
            ref int maxCurrent)
        {
            if (root == null) return;
           
            int maxLeft = 0;
            LongestUnivaluePath(root.left, ref maxThruCurrent, ref maxLeft);
           
            int maxRight = 0;
            LongestUnivaluePath(root.right, ref maxThruCurrent, ref maxRight);

            int currentMaxThruCurrent = 0;
            if (root.left != null && root.val == root.left.val)
            {
                currentMaxThruCurrent += (1 + maxLeft);
                maxCurrent = Math.Max(maxCurrent, 1 + maxLeft);
            }            

            if (root.right != null && root.val == root.right.val)
            {
                currentMaxThruCurrent += (1 + maxRight);
                maxCurrent = Math.Max(maxCurrent, 1 + maxRight);
            }           
        
            maxThruCurrent = Math.Max(currentMaxThruCurrent, maxThruCurrent);
        }
    }
}
