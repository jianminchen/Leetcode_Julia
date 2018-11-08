using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _222_count_complete_node
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
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);

            node1.left  = node2;
            node1.right = node3;
            node2.left  = node4;
            node2.right = node5;
            node3.left  = node6;

            var number = CountNodes(node1); 
        }

        /// <summary>
        /// count nodes in the tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountNodes(TreeNode root)
        {
            if (root == null)
                return 0;

            var height = getHeight(root);

            int count = 0;
            var heightRight = getHeight(root.right);
            if (heightRight == height - 1)
            {
                // since left subtree is a complete binary tree
                count += 1; // root node
                count += (1 << heightRight) - 1; // left subtree
                count += CountNodes(root.right); // right subtree
            }
            else
            {
                // since right subtree is a complete binary tree
                count += 1;                
                count += CountNodes(root.left);
                count += (1 << heightRight) - 1;
            }

            return count; 
        }

        private static int getHeight(TreeNode root)
        {
            int index = 0;
            while (root != null)
            {
                root = root.left;
                index++;
            }

            return index; 
        }
    }
}
