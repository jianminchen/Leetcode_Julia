using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_May29
{
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
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root == p || root == q)
                return root;

            // post order traversal
            var left  = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

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
