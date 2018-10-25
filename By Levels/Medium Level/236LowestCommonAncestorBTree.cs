using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestorBTree
{   
    class TreeNode
    {
	    public int val;
	    public TreeNode left;
	    public TreeNode right;

	    public TreeNode(int x)  {
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
         * 
         * 3. Method C: 
         * Cannot pass leetcode online judge
         * 
         * 4. Method D: 
         * Cannot pass leetcode online judge 
         */
        static void Main(string[] args)
        {
            TreeNode n1 = new TreeNode(1);
            n1.left = new TreeNode(2);
            n1.right = new TreeNode(3);
            n1.left.left = new TreeNode(4);
            n1.left.right = new TreeNode(5);
            n1.right.left = new TreeNode(6);
            n1.right.right = new TreeNode(7);

            TreeNode r = lowestCommonAncestorBTree_C(n1, n1.right.left, n1.left.right);

            // failed test case 
            TreeNode n2 = new TreeNode(37); 
            
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

        public static int countingProblem(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return 0;

            int matches = countingProblem(root.left, p, q) + countingProblem(root.right, p, q);

            if (root == p || root == q)
                return 1 + matches;
            else
                return matches;
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
        public static TreeNode LowestCommonAncestor_A(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null  || q == null ) 
                return null;

            if (root == p || root == q) 
                return root;

            // go left
            int no = countingProblem(root.left, p, q);

            // no: 0, 1, 2 
            bool goRight  = no == 0; 
            bool foundIt  = no == 1;
            bool goLeft   = no == 2;            

            // found it! it is root! 
            if (foundIt)
                return root;

            // go left
            else if (goLeft)
                return LowestCommonAncestor_A(root.left, p, q);

            // go right
            else if (goRight)
                return LowestCommonAncestor_A(root.right, p, q);
            
            return null;  
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

        public static TreeNode LowestCommonAncestor_B(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) 
                return null;

            if (root == p || root == q) 
                return root;

            TreeNode L = LowestCommonAncestor_B(root.left, p, q);
            TreeNode R = LowestCommonAncestor_B(root.right, p, q);

            if (L!=null && R!=null) return root;  // if p and q are on both sides

            return (L!=null) ? L : R;  // either one of p,q is on one side OR p,q is not in L&R subtrees
       }

        /**
        * Leetcode: 
        * Lowest Common Ancestor of a Binary Tree
        * source code from the blog:
        * http://huangyawu.com/leetcode-lowest-common-ancestor-of-a-binary-tree/ 
        * 
        * 
        * julia's comment: 
        *   To my surprise, the checking is much more relaxed than I thought: 
        *   if one of two nodes is visited, then, stop; another node may be in the 
        *   subtree, maybe not; but return the node anyway. 
        *   
        *   if left, right both are not null - root - one node is in left tree, 
                     one node is in right tree
            else if left is null, then, right
            else if right not null, then left 
        * 
        * Online judge: failed 
        * 
        * 29 / 31 test cases passed.
        * 
        * Input:
           [37,-34,-48,null,-100,-100,48,null,null,null,null,-54,null,-71,-22,null,null,null,8], 
        *  node with value -100, node with value -71
           Output:
           37
           Expected:   
           -48
        */
        public static TreeNode lowestCommonAncestorBTree_C(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || root.val == p.val || root.val == q.val)
                return root;

            TreeNode left = lowestCommonAncestorBTree_C(root.left, p, q);
            TreeNode right = lowestCommonAncestorBTree_C(root.right, p, q);
            return left == null ? right : right == null ? left : root;
        }


        /*
         * julia's comment: 
         * 1. leetcode online judge 
         * lowest common ancestor for binary tree - Question No: 236
         * 
         * 
         */
        public static TreeNode lowestCommonAncestorBTree_D(TreeNode root, TreeNode p, TreeNode q)
        {
            bool node1Find = false, node2Find = false;
            return findFather(root, p, q, ref node1Find, ref node2Find); 
        }

        /*
         * source code from blog:
         * http://www.cnblogs.com/chkkch/archive/2012/11/26/2788795.html
         * 递归版本：空间O(1)，时间O(n)
         * 
         * 
         * julia's comment: 
         * convert C++ to C#
         */
        public static TreeNode findFather(TreeNode root, TreeNode node1, TreeNode node2, ref bool node1Find, ref bool node2Find)
        {
            if (root == null)
                return null;
 
            bool leftNode1Find = false, leftNode2Find = false;

            TreeNode leftNode = findFather(root.left, node1, node2, ref leftNode1Find, ref leftNode2Find);

            if (leftNode != null)
                return leftNode;
 
            bool rightNode1Find = false, rightNode2Find = false;
            TreeNode rightNode = findFather(root.right, node1, node2, ref rightNode1Find, ref rightNode2Find);

            if (rightNode != null)
                return rightNode;
 
            node1Find = leftNode1Find || rightNode1Find;
            node2Find = leftNode2Find || rightNode2Find;
 
            if (node1Find && node2Find)
                return root;
 
            if (root == node1)
                node1Find = true;
 
            if (root == node2)
                node2Find = true;
 
            return null;
        }
    } 
}
