using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_114_Flatten_binary_tree_to_linked_list___practice
{
    /// <summary>
    /// Leetcode 114 - flatten binary tree to linked list 
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode currentNode;
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;

            // if there is at least one child, list more than 2 nodes
            var left = root.left;
            var right = root.right;

            currentNode = root;

            Flatten(root.left);

            // currentNode should be the last node of left subtree
            if (left != null)
                root.right = left;

            root.left = null;

            if (currentNode != null)
            {
                currentNode.left = null;
                currentNode.right = right;
            }

            Flatten(root.right);            
        }       
    }
}
