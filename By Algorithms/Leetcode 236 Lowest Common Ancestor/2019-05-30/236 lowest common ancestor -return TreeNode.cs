using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_III
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

        public static TreeNode lowestCommonAncestor; 
        /// <summary>
        /// May 30, 2019
        /// lowest common ancestor
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            lowestCommonAncestor = null;
            LowestCommonAncestorHelper(root, p, q);
            return lowestCommonAncestor;
        }

        /// <summary>
        /// May 30, 2019
        /// recursive function: 
        /// Return node found in binary tree. 
        /// If more than one node is found, then one of node is returned. 
        /// Debate of return TreeNode or bool:
        /// The problem of design is no need to return TreeNode since bool is good enough. 
        /// The lowest common ancestor can be found through the root node itself. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private static TreeNode LowestCommonAncestorHelper(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;
            // post order traversal
            var left = LowestCommonAncestorHelper(root.left, p, q);
            var right = LowestCommonAncestorHelper(root.right, p, q);

            if (left != null && right != null)
            {
                lowestCommonAncestor = root;
            }

            if (root == p || root == q)
            {
                if (left != root && left != null)
                {
                    lowestCommonAncestor = root;
                }

                if (right != root && right != null)
                {
                    lowestCommonAncestor = root;
                }
            }

            if (root == p || root == q)
                return root;

            if (left != null)
            {
                return left;
            }

            if (right != null)
            {
                return right;
            }

            return null;
        }
    }
}
