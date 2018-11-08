using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _450_delete_a_node_in_BST
{
    public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RunTestcase(); 
        }

        public static void RunTestcase()
        {
            var node5 = new TreeNode(5);
            var node3 = new TreeNode(3);
            var node6 = new TreeNode(6);
            var node2 = new TreeNode(2);
            var node4 = new TreeNode(4);
            var node7 = new TreeNode(7);

            node5.left  = node3;
            node5.right = node6;

            node3.left = node2;
            node3.right = node4;

            node6.right = node7;

            var node = DeleteNode(node5, 3);
        }

        /// <summary>
        /// binary search tree - inorder traversal - Left, root, right          
        /// </summary>
        /// <param name="root"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static TreeNode DeleteNode(TreeNode root, int key)
        {
            if (root == null)
                return null;

            if (root.val == key)
            {
                if (root.left == null)
                {
                    return root.right;
                }
                else if (root.right == null)
                {
                    return root.left;
                }
                else
                {
                    // Need to find left subtree's maximum/ or right subree's minimum
                    TreeNode maximumNode = new TreeNode(1);
                    var node = DeleteMaximumNode(root.left, ref maximumNode);
                    
                    maximumNode.left = node;                    

                    maximumNode.right = root.right; 
                    return maximumNode; 
                }
            }
            else if (root.val > key)
            {
                root.left = DeleteNode(root.left, key);
                return root;
            }
            else
            {
                root.right = DeleteNode(root.right, key);
                return root; 
            }
        }

        public static TreeNode DeleteMaximumNode(TreeNode root, ref TreeNode maximumNode)
        {
            if (root == null)
                return null;

            if (root.left == null && root.right == null)
            {
                maximumNode = root; // caught up by test case given by problem statement
                return null;
            }

            if (root.right == null)
            {
                maximumNode = root;
                return root.left;
            }

            root.right = DeleteMaximumNode(root.right, ref maximumNode);
            return root;          
        }
    }
}
