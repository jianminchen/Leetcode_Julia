using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _235LowestCommonAncestorBinarySearchTree
{
     /*
         * Leetcode question 235
         * Lowest common ancestor in binary search tree 
         * January 6, 2016
      */
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            left = null;
            right = null;
            val = x;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
            TreeNode n1 = new TreeNode(4);

            n1.left         = new TreeNode(2);
            n1.right        = new TreeNode(6);
            n1.left.left    = new TreeNode(1);
            n1.left.right   = new TreeNode(3);
            n1.right.left   = new TreeNode(5);
            n1.right.right  = new TreeNode(7);

            TreeNode r = LCA(n1, n1.right.left, n1.left.right);

            TreeNode r2 = LCA(n1, n1.left.left, n1.left.right);
        }

        /*
         * January 6, 2016
         * blog: 
           https://github.com/mengli/leetcode/blob/master/LowestCommonAncestorOfaBinarySearchTree.java
         * 
         * Make two changes:
         * 1. use short name - LCA
         * 2. use Math.Max and Math.Min function 
         * 
         */
        public static TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)    // bug001 fix
                return null;

            if (root.val < Math.Min(p.val, q.val))
                return LCA(root.right, p, q);
            else if (root.val > Math.Max(p.val, q.val))
                return LCA(root.left, p, q);
            else
                return root;
        }

        /*
         * January 6, 2016
         *         
         * 
         * Bug001 - fix 
         * Work on base case again, add two more checking - p and q 
         */
        public static TreeNode lowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)    // bug001 fix
                return null;

            if (root.val < p.val && root.val < q.val)
                return lowestCommonAncestor(root.right, p, q);
            else if (root.val > p.val && root.val > q.val)
                return lowestCommonAncestor(root.left, p, q);
            else
                return root;
        }

        /*
         * Leetcode question 235
         * Lowest common ancestor in binary search tree 
         * January 6, 2016
         * 
         * p or q may be null pointer, so p.val or q.val cannot be accessed. 
         * Base Case is wrong - Sorry! 
         * 
         */
        public static TreeNode lowestCommonAncestor_bug(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            if (root.val < p.val && root.val < q.val)
                return lowestCommonAncestor_bug(root.right, p, q);
            else if (root.val > p.val && root.val > q.val)
                return lowestCommonAncestor_bug(root.left, p, q);
            else
                return root;
        }
    }
}
