using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor__stack
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
        /// June 10, 2019
        /// Use stack as return 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            var stackP = preOrderTraversal(root, p);
            var stackQ = preOrderTraversal(root, q);

            TreeNode lowestCommonAncestor = null;
            while (stackP.Count > 0 && stackQ.Count > 0)
            {
                var p1 = stackP.Pop();
                var q1 = stackQ.Pop();
                if (p1 == q1)
                {
                    lowestCommonAncestor = p1;
                }
                else
                    break;
            }

            return lowestCommonAncestor;
        }

        /// <summary>
        /// recursive function design: return a stack 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        private static Stack<TreeNode> preOrderTraversal(TreeNode root, TreeNode p)
        {
            if (root == null)
                return new Stack<TreeNode>();

            if (root == p)
            {
                var stack = new Stack<TreeNode>();
                stack.Push(root);
                return stack;
            }

            var left = preOrderTraversal(root.left, p);
            var right = preOrderTraversal(root.right, p);

            if (left.Count > 0)
            {
                left.Push(root);
                return left;
            }

            if (right.Count > 0)
            {
                right.Push(root);
                return right;
            }

            return new Stack<TreeNode>();
        }
    }
}
