using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_563_binary_tree_tilt
{
    /// <summary>
    /// Leetcode 563 binary tree tilt
    /// </summary>
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
        }

        public int FindTilt(TreeNode root)
        {
            if (root == null)
                return 0;            

            var leftSum  = getSum(root.left);
            var rightSum = getSum(root.right);

            return Math.Abs(leftSum - rightSum) + FindTilt(root.left) + FindTilt(root.right);
        }

        private int getSum(TreeNode root)
        {
            if (root == null)
                return 0;

            return root.val + getSum(root.left) + getSum(root.right); 
        }
    }
}
