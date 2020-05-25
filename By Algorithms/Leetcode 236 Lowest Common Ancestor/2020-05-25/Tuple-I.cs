using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_Tuple
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
        /// warmup practice on May 25, 2020
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            // apply post order, and also using strong type Tuple<TreeNode, int> as return argument, 
            // first one is LCA TreeNode, second one is the count of nodes found
            var tuple = traversePostOrder(root, p, q);
            return tuple.Item1;
        }

        /// <summary>
        /// apply postorder, bottom up
        /// check two results:
        /// LCA and count of nodes found
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        private Tuple<TreeNode, int> traversePostOrder(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return new Tuple<TreeNode, int>(null, 0);
            }

            // postorder
            var left = traversePostOrder(root.left, p, q);
            var right = traversePostOrder(root.right, p, q);

            if (left.Item1 != null)
            {
                return left;
            }

            if (right.Item1 != null)
            {
                return right;
            }

            var countRoot = (root == p || root == q)? 1 :0;
            var count = left.Item2 + right.Item2 + countRoot;
            if (count == 2)
            {
                return new Tuple<TreeNode, int>(root, 2);
            }

            return new Tuple<TreeNode, int>(null, count); 
        }
    }
}
