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
            left  = null;
            right = null;
            val   = x;
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
        *  source code from blog:
        *  http://articles.leetcode.com/2011/07/lowest-common-ancestor-of-a-binary-tree-part-i.html
        *  
         * A Top-Down Approach (Worst case O(n^2) ):
         * 
         *  julia's comment:         
            1.  check left subtree count of matching p or q: 
               0 - no match in left sub tree, so go to check right subtree
               1 - found it, the root is the node
               2 - continue to left, check 
         *  2. put the code in the certain order: root, left, right
         *     so, making it easy to follow. 
         *     two orders: 
         *      1. check countingProblem return value, from 0 to 1 to 2, increasing order
         *      2. using countingProblem calculation take action, "found it", "go left", 
         *         "go right" three choice. 
         *      
         *      Keep the code in the above order, this way, easy to memorize, explain, and discuss.
         *      
         *  3. Using a easy counting problem to help solve lowest common ancestor (LCA), 
         *     What is the thinking process? 
         *     Here is the scripts Julia makes out: 
         *     Go to visit root first, check it value, null or one of two nodes, 
         *     and then, decide to find LCA, or go left to find it or go right to find it. 
         *     
         *     But wait, how to decide to find it, or go left/ right, so calculate the left sub tree 
         *     matching count first, use its value to determine.  
         *     
         *  4. online judge: (lowest common ancestor in binary search tree, not in binary tree)
         *      27 / 27 test cases passed.
                Status: Accepted
                Runtime: 180 ms
         *      
         */
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            if (root == p || root == q)
                return root;

            // go left
            int leftTreeMatched = findMatches(root.left, p, q);
            
            bool zeroFound = leftTreeMatched == 0;
            bool oneFound  = leftTreeMatched == 1;
            bool twoFound  = leftTreeMatched == 2;
             
            if (oneFound)
            {
                return root;
            }
            else if (twoFound)
            {
                return LowestCommonAncestor(root.left, p, q);
            }
            else if (zeroFound)
            {
                return LowestCommonAncestor(root.right, p, q);
            }

            return null;
        }

        /*
         *  source code from blog:
         *  http://articles.leetcode.com/2011/07/lowest-common-ancestor-of-a-binary-tree-part-i.html
         *  comment from blog: 
         *  A Top-Down Approach (Worst case O(n^2) ):
         
            Let’s try the top-down approach where we traverse the nodes from the top to the bottom. 
         *  First, if the current node is one of the two nodes, it must be the LCA of the two nodes. 
         *  If not, we count the number of nodes that matches either p or q in the left subtree (which 
         *  we call totalMatches). If totalMatches equals 1, then we know the right subtree will contain
         *  the other node. Therefore, the current node must be the LCA. If totalMatches equals 2, we know
         *  that both nodes are contained in the left subtree, so we traverse to its left child. Similar 
         *  with the case where totalMatches equals 0 where we traverse to its right child.
         *  
         *  Return #nodes that matches P or Q in the subtree.
         * 
         *  julia's comment: 
         *  1. Convert C++ code to C#
         *  2. Solve a problem first: counting matches in the tree
         *     Counting always helps to make decision. Using number to make a decision
         *  3. think about the question: 
         *     Can this function only uses two line code? 
         *         
         *  
         */
        private static int findMatches(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return 0;

            int matches = findMatches(root.left, p, q) + findMatches(root.right, p, q);

            if (root == p || root == q)
            {
                return 1 + matches;
            }
            else
            {
                return matches;
            }
        }
    }
}