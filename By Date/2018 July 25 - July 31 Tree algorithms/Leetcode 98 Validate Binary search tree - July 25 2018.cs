using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_98_Validate_binary_search_tree
{
    /// <summary>
    /// Leetcode 98 - validate binary search tree
    /// code review 7/25/2018
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

        public bool IsValidBST(TreeNode root)
        {
            return checkBSTValidWithRange(root, long.MinValue, long.MaxValue);
        }

        /// <summary>
        /// By giving range minimum and maximum, the tree is also forced to give 
        /// left child smaller than parent node, right child bigger than parent node
        /// </summary>
        /// <param name="node"></param>
        /// <param name="rangeMin"></param>
        /// <param name="rangeMax"></param>
        /// <returns></returns>
        private static bool checkBSTValidWithRange(TreeNode node, long rangeMin, long rangeMax)
        {
            if (node == null)
                return true;

            var current = node.val;
            
            if (current <= rangeMin || current >= rangeMax) // bug catched: = should be included
                return false;

            var checkLeftSubTree = checkBSTValidWithRange(node.left, rangeMin, current);  
            if (!checkLeftSubTree)
                return false;

            var checkRightSubtree = checkBSTValidWithRange(node.right, current, rangeMax); 
            if (!checkRightSubtree)
                return false;

            return true;
        }
    }
}
