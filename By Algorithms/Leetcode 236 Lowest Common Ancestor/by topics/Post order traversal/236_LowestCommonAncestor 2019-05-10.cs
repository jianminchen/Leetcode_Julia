using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor
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

        public static TreeNode ancestor = null;

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            ancestor = null;

            postOrderTraversalSearch(root, p, q);

            return ancestor;
        }

        /// <summary>
        /// bottom up, post order traversal. 
        /// Each node checks its left child and right child to see if  node p or node q is found.
        /// Also the node itself is compared to node p and node q. 
        /// If there is one found in root itself or its subtrees, then return true. 
        /// Based on this recursive function, add the checking if lowest common ancestor is found. 
        /// Time complexity: O(N), N is total nodes in the tree. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private static bool postOrderTraversalSearch(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || ancestor != null)
                return false;

            var left = postOrderTraversalSearch(root.left, p, q);
            var right = postOrderTraversalSearch(root.right, p, q);

            //   left and right both      root itself             one of child
            if ((left && right) || ((root == p || root == q) && (left || right)))
            {
                ancestor = root;
            }

            return (root == p || root == q) || (left || right);
        }
    }
}