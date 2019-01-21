using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_univalue_path___follow_up
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
        /// <summary>
        /// The code is written after the mock interview as an interivewer on January 18, 2019
        /// http://juliachencoding.blogspot.com/2019/01/case-study-longest-univalue-path-mock_19.html
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
        }

        public static int crossPath;
        public static int LongestUnivaluePath(TreeNode root)
        {
            crossPath = 0;

            postOrderTraversal(root);

            return crossPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="crossPath"></param>
        /// <returns></returns>
        private static int postOrderTraversal(TreeNode root)
        {
            if (root == null)
                return 0;

            // structure post order traversal clearly
            var left = postOrderTraversal(root.left);
            var right = postOrderTraversal(root.right);

            // deal with root node related calculation
            var currentCrossPath = 0;
            if (root.left != null && root.val == root.left.val)
            {
                left++;
                currentCrossPath += left;
            }
            else
            {
                left = 0;
            }

            if (root.right != null && root.val == root.right.val)
            {
                right++;
                currentCrossPath += right;
            }
            else
            {
                right = 0;
            }

            crossPath = Math.Max(currentCrossPath, crossPath);

            return Math.Max(left, right);
        }
    }
}
