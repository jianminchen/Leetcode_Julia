using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestorBTree
{
    /// <summary>
    /// code review on July 9, 2018
    /// Leetcode 236
    /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/description/
    /// </summary>
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

    class LowestCommonAncestorB
    {
        /*
         * Leetcode: 
         * Lowest common ancestor in binary tree 
         * 
         * Try a few of implementations - 4 different ones:
         * 1. Method A: 
         * Top down method, using counting method to help 
         *    worst case time O(N^2) 
         *    
         * 2. Method B: 
         * A Bottom-up Approach (Worst case O(n) ):
           Using a bottom-up approach, we can improve over the top-down approach 
           by avoiding traversing the same nodes over and over again.       
         */
        static void Main(string[] args)
        {
            var root   = new TreeNode(1);
            root.left  = new TreeNode(2);
            root.right = new TreeNode(3);

            root.left.left  = new TreeNode(4);
            root.left.right = new TreeNode(5);

            root.right.left  = new TreeNode(6);
            root.right.right = new TreeNode(7);

            var ancestor = LowestCommonAncestor(root, root.right.left, root.left.right);
        }

        /*
         * source code from blog:
         * http://articles.leetcode.com/2011/07/lowest-common-ancestor-of-a-binary-tree-part-i.html
         * 
         * A Bottom-up Approach (Worst case O(n) ):
           Using a bottom-up approach, we can improve over the top-down approach 
           by avoiding traversing the same nodes over and over again.
           We traverse from the bottom, and once we reach a node which matches one 
           of the two nodes, we pass it up to its parent. The parent would then test 
           its left and right subtree if each contain one of the two nodes. If yes, then 
         * the parent must be the LCA and we pass its parent up to the root. If not, we 
         * pass the lower node which contains either one of the two nodes (if the left 
         * or right subtree contains either p or q), or NULL (if both the left and 
         * right subtree does not contain either p or q) up.
         * 
         * julia's comment:
         * 1. Leetcode online judge - lowest common ancestor in binary tree
         *      31 / 31 test cases passed.
                Status: Accepted
                Runtime: 172 ms
         * 
         * */

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
            {
                return null;
            }

            if (root == p || root == q)
            {
                return root;
            }

            var leftOne  = LowestCommonAncestor(root.left, p, q);
            var rightOne = LowestCommonAncestor(root.right, p, q);

            if (leftOne != null && rightOne != null)
            {
                return root;  // if p and q are on both sides
            }

            return (leftOne != null) ? leftOne : rightOne;  // either one of p,q is on one side OR p,q is not in L&R subtrees
        }
    }
}