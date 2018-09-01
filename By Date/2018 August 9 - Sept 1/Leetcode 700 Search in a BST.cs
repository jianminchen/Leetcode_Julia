using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_700_search_in_a_bst
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

        /// <summary>
        /// time complexity: O(logN), N is the total number of nodes
        /// </summary>
        /// <param name="root"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null)
                return null;

            var current = root.val;
            if (current == val)
            {
                return root;
            }
            else if (current < val)
            {
                return SearchBST(root.right, val);
            }
            else
            {
                return SearchBST(root.left, val);
            }
        }
    }
}
