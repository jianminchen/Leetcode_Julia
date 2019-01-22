using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_longest_univalue_path___code_to_review
{
    public class TreeNode
    {
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

        /// <summary>
        /// the source code is from
        /// http://anothercasualcoder.blogspot.com/2018/12/largest-binary-search-tree-bst-by-apple.html
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestUnivaluePath(TreeNode root)
        {
            int maxThruCurrent = 0;
            int maxCurrent = 0;
            int maxGlobal = 0;
            LongestUnivaluePath(root, ref maxThruCurrent, ref maxCurrent, ref maxGlobal);
            return maxGlobal;
        }

        private void LongestUnivaluePath(
            TreeNode root,
            ref int maxThruCurrent,
            ref int maxCurrent,
            ref int maxGlobal)
        {
            if (root == null) return;

            int maxThruLeft = 0;
            int maxLeft = 0;
            LongestUnivaluePath(root.left, ref maxThruLeft, ref maxLeft, ref maxGlobal);

            int maxThruRight = 0;
            int maxRight = 0;
            LongestUnivaluePath(root.right, ref maxThruRight, ref maxRight, ref maxGlobal);

            if (root.left != null && root.val == root.left.val)
            {
                maxThruCurrent += (1 + maxLeft);
                maxCurrent = Math.Max(maxCurrent, 1 + maxLeft);
            }

            if (root.right != null && root.val == root.right.val)
            {
                maxThruCurrent += (1 + maxRight);
                maxCurrent = Math.Max(maxCurrent, 1 + maxRight);
            }

            maxGlobal = Math.Max(maxGlobal, Math.Max(maxThruCurrent, maxCurrent));
        }
    }
}
