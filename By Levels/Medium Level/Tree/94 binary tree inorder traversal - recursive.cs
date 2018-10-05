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
        public class TreeNode {
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
        /// code review on 10/4/2018
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> InorderTraversal(TreeNode root) // emtpy tree, with one root node, with more nodes
        {
            if (root == null)
            {
                return new List<int>(); 
            }

            var left = InorderTraversal(root.left);
            left.Add(root.val);
            var right = InorderTraversal(root.right);

            // add right to left list
            if (right.Count > 0)
            {
                foreach (var item in right)
                {
                    left.Add(item);
                }
            }

            return left; 
        }
    }
}
