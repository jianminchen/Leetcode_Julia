using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor___p_or_q_not_in_binary_tree
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
        /// Extended algorithm:
        /// 236 lowest common ancestor - given node p and q in binary tree
        /// What if p or q is not guaranteed in binary tree? 
        /// - add a few more lines of code to check if another node is in binary tree
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var node = LowestCommonAncestorHelper(root, p, q);
            if (node == null)
                return null;
            bool foundSecondNode = false;
            if (node == p)
            {
                foundSecondNode = treeTraverse(root, q);
            }
            else
                foundSecondNode = treeTraverse(root, p);
            if (foundSecondNode)
                return node;
            else
                return null;
        }

        private bool treeTraverse(TreeNode root, TreeNode node)
        {
            if (root == null)
                return false;
            if (root == node)
                return true;

            return treeTraverse(root.left, node) || treeTraverse(root.right, node);
        }

        /// <summary>
        /// May 29, 2019
        /// assuming that p and q both are in the binary tree, 
        /// the recursive function will find the common ancestor. 
        /// Two cases:
        /// 1. p and q are in separate side of the root node; 
        /// 2. p and q are in the same side of the root node, node p or q is the ancestor of the other node. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private TreeNode LowestCommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;

            // post order traversal
            var left  = LowestCommonAncestorHelper(root.left, p, q);
            var right = LowestCommonAncestorHelper(root.right, p, q);

            if (left != null && right != null)
            {
                return root;
            }

            if (left != null)
                return left;
            else if (right != null)
                return right;
            else
                return null;
        }
    }
}
