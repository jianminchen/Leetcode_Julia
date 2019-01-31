using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _783_minimum_distance_between_BST
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
        }

        public static TreeNode previous;
        public static int minDifference;

        public int MinDiffInBST(TreeNode root)
        {
            minDifference = int.MaxValue; 
            inorderTraversal(root);
            return minDifference;
        }

        private static void inorderTraversal(TreeNode root)
        {
            if (root == null)
                return;
            inorderTraversal(root.left);

            var current = root.val;
            if (previous != null)
            {
                var diff = Math.Abs(current - previous.val);
                minDifference = diff < minDifference ? diff : minDifference;
            }

            previous = root; 

            inorderTraversal(root.right);
        }
    }
}
