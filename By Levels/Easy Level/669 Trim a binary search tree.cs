using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_669_Trim_a_binary_search_tree
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

        public TreeNode TrimBST(TreeNode root, int L, int R)
        {
            if (root == null || L > R)
                return null;

            var current = root.val;
            if (current > R)
                return TrimBST(root.left, L, R);

            if (current < L)
                return TrimBST(root.right, L, R);

            // current >= L and current <= R
            root.left = TrimBST(root.left, L, R);
            root.right = TrimBST(root.right, L, R);

            return root;
        }
    }
}