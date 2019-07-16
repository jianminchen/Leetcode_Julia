using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _98_validate_BST___post_order
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

        public bool IsValidBST(TreeNode root)
        {
            return IsValidBST_B(root, long.MinValue, long.MaxValue);
        }

        /// July 16, 2019
        /// tip is to use long.MinValue and long.MaxValue
        /// int.MinValue and int.MaxValue will not work.                
        public static bool IsValidBST_B(TreeNode node, long MIN, long MAX)
        {
            if (node == null)
                return true;

            var isInRange = node.val > MIN && node.val < MAX;
            if (!isInRange)
                return false;

            var left  = IsValidBST_B(node.left, MIN, node.val);
            var right = IsValidBST_B(node.right, node.val, MAX);

            return left && right;
        }  
    }
}
