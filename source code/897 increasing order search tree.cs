using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _897_increasing_order_search_tree
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
            var node5 = new TreeNode(5);
            var node3 = new TreeNode(3);
            var node6 = new TreeNode(6);
            var node4 = new TreeNode(4);
            var node2 = new TreeNode(2);
            var node1 = new TreeNode(1);

            node5.left = node3;
            node5.right = node6;
            node3.left = node2;
            node3.right = node4;
            node2.left = node1;

            var result = IncreasingBST(node5); 

        }

        private static TreeNode previousNode;
        private static TreeNode currentNode;
        private static TreeNode head; 
        /// <summary>
        /// post order traversal - visit each node once
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static TreeNode IncreasingBST(TreeNode root)
        {
            if (root == null)
                return root;
            previousNode = null;
            currentNode = null;
            head = null;

            inorderTraversal(root);
            return head; 
        }

        private static void inorderTraversal(TreeNode root)
        {
            if (root == null)
                return;           
            
            // inorder traveral - left node
            inorderTraversal(root.left);                              

            // visit root node
            if (head == null)
            {
                head = root;
            }

            currentNode = root;
            if (previousNode != null)
            {
                previousNode.right = currentNode;
                previousNode.left = null;
            }

            // reset current, previous
            previousNode = currentNode;
            currentNode.left = null; 
            
            // In order traversal - right
            inorderTraversal(root.right);  
        }
    }
}
