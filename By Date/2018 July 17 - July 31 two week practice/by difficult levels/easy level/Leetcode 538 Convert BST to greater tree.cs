using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_538_convert_BST_to_greater_tree
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
            var node  = new TreeNode(5);
            var node2 = new TreeNode(13);
            var node3 = new TreeNode(2);

            node.left = node3;
            node.right = node2;

            var root = ConvertBST(node);
        }

        public static TreeNode ConvertBST(TreeNode root)
        {
            var suffixSum = 0;

            return convertBST_RightRootLeftTraverse(root, ref suffixSum);
        }

        /// <summary>
        /// time complexity: 
        /// O(N) - N is total nodes in the binary search tree
        /// traverse the nodes from biggest one to smallest one in descending order. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="suffixSum"></param>
        /// <returns></returns>
        private static TreeNode convertBST_RightRootLeftTraverse(TreeNode root, ref int suffixSum)
        {
            if (root == null)
                return root; 

            // traverse the tree using right, root, left order 
            convertBST_RightRootLeftTraverse(root.right, ref suffixSum);
            var addValue = root.val; // bug catched by online judge, issue with sample test case

            root.val = root.val + suffixSum;
            suffixSum += addValue;
            convertBST_RightRootLeftTraverse(root.left, ref suffixSum);

            return root;
        }
    }
}
