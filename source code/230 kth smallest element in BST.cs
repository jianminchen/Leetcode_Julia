using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _230_kth_smallest_element_in_BST
{
    public class TreeNode
    {
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
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);

            node3.left  = node1;
            node3.right = node4;
            node1.right = node2;

            var result = KthSmallest(node3, 1);
        }

        /// <summary>
        /// Inorder traversal the tree, it will take O(k) time to find kth smallest element
        /// </summary>
        /// <param name="root"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int KthSmallest(TreeNode root, int k)
        {
            if (root == null || k < 0)
                return -1;

            int index = 1;
            int search = -1; 

            inorderTraversal(root, k, ref index, ref search);

            return search; 
        }

        private static void inorderTraversal(TreeNode root, int k, ref int index, ref int search)
        {
            if (root == null || index > k)
                return;

            inorderTraversal(root.left, k, ref index, ref search);
           
            if(k == index)
            {
                search = root.val;                               
            }

            index++; 

            inorderTraversal(root.right, k, ref index, ref search);
        }
    }
}
