using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor
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

        /// <summary>
        /// May 1, 2020
        /// Use bottom up approach, and also return number of nodes found and LCA
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var tuple = postOrderTraversal(root, p, q);
            return tuple.Item1; 
        }

        /// <summary>
        /// return LCA and count of nodes found
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private static Tuple<TreeNode, int> postOrderTraversal(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return new Tuple<TreeNode, int>(null, 0);
            }

            var left = postOrderTraversal(root.left, p, q);
            if (left.Item1 != null)
            {
                return left;
            }

            var right = postOrderTraversal(root.right, p, q);
            if(right.Item1 != null)
            {
                return right; 
            }

            int count = left.Item2 + right.Item2 + ((root == p || root == q) ? 1 : 0);
            if (count == 2)
            {
                return new Tuple<TreeNode, int>(root, 2); 
            }

            return new Tuple<TreeNode, int>(null, count); 
        }
    }
}
