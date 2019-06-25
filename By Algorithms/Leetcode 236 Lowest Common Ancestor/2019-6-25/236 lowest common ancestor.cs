using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_June_25
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static HashSet<TreeNode> path;
        public static TreeNode lowestCommonAncestor;
        /// <summary>
        /// June 25, 2019
        /// Write a solution after mock interview
        /// Find a path from given node p to the root, and then save nodes in hashset;
        /// Search q in binary tree, and then find lowest common ancestor. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            path = new HashSet<TreeNode>();
            lowestCommonAncestor = null;

            postOrderTraversal(root, p);
            postOrderTraversal(root, q);

            return lowestCommonAncestor;
        }

        /// <summary>
        /// It is to find the path and add nodes to the hashset in the first call.
        /// It is to find the lowest common ancestor in the second call. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool postOrderTraversal(TreeNode root, TreeNode p)
        {
            if (root == null || lowestCommonAncestor != null)
                return false;

            var left = postOrderTraversal(root.left, p);
            var right = postOrderTraversal(root.right, p);
            
            if (root == p || left || right)
            {
                if (path.Contains(root))
                {
                    lowestCommonAncestor = root;
                    return false; // stop traversal
                }
                else
                {
                    path.Add(root);
                    return true;
                }
            }

            return false;
        }
    }
}
