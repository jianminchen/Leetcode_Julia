using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode94_BinaryTreeInOrderTraversal
{
    /// <summary>
    /// Leetcode 94: Binary tree inorder traversal
    /// https://leetcode.com/problems/binary-tree-inorder-traversal/description/
    /// </summary>
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x)
            {
                val = x;
            }
        }

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// May 29, 2018
        /// write an iterative solution 
        /// source code reference:
        /// https://codereview.stackexchange.com/questions/159073/binary-tree-inorder-traversal-iterative-solution
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root) // emtpy tree, with one root node, with more nodes
        {
            if (root == null)
            {
                return new List<int>();
            }

            var nodes = new List<int>();

            var stack = new Stack<TreeNode>();
            stack.Push(root);

            var visited = new HashSet<TreeNode>();

            while (stack.Count > 0)
            {
                var current = stack.Peek();
                var left    = current.left;

                while (left != null && !visited.Contains(left))
                {
                    stack.Push(left);
                    left = left.left;
                }

                var visit = stack.Pop();

                nodes.Add(visit.val);

                visited.Add(visit);

                if (visit.right != null)
                {
                    stack.Push(visit.right);
                }
            }

            return nodes;
        }
    }
}
