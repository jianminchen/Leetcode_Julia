using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_114_Flatten_binary_tree_to_a_linked_list
{
    /// <summary>
    /// Leetcode 114 - flatten binary tree to a linked list
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
        public static TreeNode previousNode;
        /// <summary>
        /// test tree with three nodes
        ///      1
        ///    /   \
        ///   2     3
        ///   one more:
        ///   1 
        ///    \
        ///     3
        ///  third one:
        ///   1
        ///  /
        /// 2
        /// 
        /// fourth one:
        /// </summary>
        /// <param name="root"></param>
        public void Flatten(TreeNode root)
        {
            if (root == null)
                return;
           
            // if there is at least one child, list more than 2 nodes
            var left  = root.left;
            var right = root.right;            

            currentNode = root;

            // make sure the current node is visited in the linked list
            if (previousNode != null)
            {
                previousNode.left = null;
                previousNode.right = currentNode;
            }

            previousNode = currentNode;
            currentNode.left = null;
            
            Flatten(left);
            Flatten(right);            
        }        
    }
}
