using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _124_binary_tree_maximum_path_sum
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
        /// code review on Dec. 6, 2018
        /// Similar to longest univalue path algorithm
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxPathSum(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int maxCrossRoot = Int32.MinValue;
            int maxEndRoot = maximumRootToLeaf(root, ref maxCrossRoot);

            return Math.Max(maxEndRoot, maxCrossRoot);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="maxCrossRoot"></param>
        /// <returns></returns>
        private static int maximumRootToLeaf(TreeNode root, ref int maxCrossRoot)
        {
            if (root == null)
            {
                return 0;
            }

            int left  = maximumRootToLeaf(root.left,  ref maxCrossRoot);
            int right = maximumRootToLeaf(root.right, ref maxCrossRoot);

            int value = root.val;
            if (left > 0)
            {
                value += left;
            }

            if (right > 0)
            {
                value += right;
            }

            maxCrossRoot = value > maxCrossRoot ? value : maxCrossRoot;

            int maxValue = Math.Max(root.val + left, root.val + right);

            return Math.Max(root.val, maxValue);
        }
    }
}
