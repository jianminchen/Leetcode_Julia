using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99RecoveryBinarySearchTree_C
{
    public class TreeNode
    {
        public int val;

        public TreeNode left;
        public TreeNode right;

        public TreeNode(int v)
        {
            val = v;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
         * Problem: Leetcode 99 - recover binary search tree
         * Reference: 
         * https://github.com/jianminchen/Leetcode_C-/blob/master/99RecoverBinarySearchTree.cs
         * 
         * julia's comment:
         * 1. Extract two functions: 
         *    findTheInorderPredecessorOfCurrent
         *    violationChecking        
         * 
         * 2. Add test cases for those two functions, 
         *    make them memorizable, testable, maintainable
         *   
         * 3. online judge passes
         *  1916 / 1916 test cases passed.
	        Status: Accepted
            Runtime: 324 ms
         * 
         * 4. Read the code, and write down the script: 
         * Actually it is in Morris order traversal, not using stack; use the existing right 
         * child pointer connect the traversal nodes, later revert the change. 
         * 
         * First, use two violation nodes, 3 nodes: current node, previous node, parent node to help
         * tracking the inorder traversal process. 
         * 
         * base case discussion: root node is null, return
         * start from root node, get in a loop, 
         * 
         * if node in the loop (ith)'s left child is null, then, 
         * do a violation checking function call using parent node (pa), ith node input arguments, 
         * after the call, recover phase: ith node is set as pa node, ith.right is ith node (go to its right child).
         * using example to explain: 
         *     1 
         *      \
         *       3
         *      / \ 
         *      2  4
         *    starting from root node (1), (1)'s left child is empty, and then, before moving to next node:
         *    (1)'s right child (3), do violation check, and then, set ith's node to (3), and parent node as ith's node (1). 
         * 
         * else if ith's left child is not null, then, 
         * find predecessor node  of ith's node, denoted as previous node (pr), 
         * if pr's right child is null, then, threaded link is not set up, 
         * so, set up the link before moving to ith's node's next one - its left child; 
         * else if pr's right child is not null, then, 
         *     break the threaded link; 
         *     do violation check, two node, pa, ith; 
         *     recover phase, set parent node pa = ith, and then, move to ith's right node. 
         *     
         * using example to explain the work here:
         *       4
         *      /
         *     2
         *    / \ 
         *    1  3
         *    starting from root node (4), (4)'s left child is not null, and then, find its inorder 
         *    predecessor node (3), 
         *     case A: node (3)'s right child is not set up to node (4), then, 
         *     set up node (3)'s right = node (4), move ith's node's left node, node (2). 
         *     
         *     case B: node (3)'s right child is already set up to node (4), then
         *     revert the change, (3).right = null
         *     do violation check, parent node pa, ith node, 
         *     recover phase: set parent node pa as ith node, and then, move to ith's right node. 
         *     
         *     What we miss here, Morris order second visit of node 4. how to do traversal? 
         *     visit (4), then, set up (3)'s right = (4), so, continue to travel, 4->2. 
         *     output of inorder traversal only happens two cases: 
         *       one is to travel fake link, right child; second one is to travel to its right child.  
         *     
         *  
         * 
         */
        public static void recoverTree(TreeNode root)
        {
            TreeNode v1 = null,     // two vilation nodes, v1 and v2 
                     v2 = null;

            TreeNode ith,           // ith - current node, node will go through inorder traversal                                      
                     pr,            // pr - previous node
                     pa = null;     // pa - parent node

            if (root == null)
                return;

            bool found = false;

            ith = root;       // start from root node r
            // pa = null, and pr = null 

            while (ith != null)    // need to get into the inorder traversal without a stack - O(n) space
            {
                if (ith.left == null)
                {
                    violationChecking(pa, ith, ref v1, ref v2, ref found);

                    pa = ith;         // recover phase, go to next node; 
                                      // no left, then, go to the right. 
                    ith = ith.right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pr = findTheInorderPredecessorOfCurrent(ith);

                    /* Make current as right child of its inorder predecessor */
                    if (pr.right == null)
                    {
                        pr.right = ith;
                        ith = ith.left;  // go to next iteration, left child. 
                    }

                    /* Revert the changes made in if part to restore the original
                    tree i.e., fix the right child of predecssor */
                    else
                    {
                        pr.right = null;   // revert the change. Why? Remember? 

                        violationChecking(pa, ith, ref v1, ref v2, ref found);

                        pa = ith;
                        ith = ith.right;    // go to next iteration, no left child, so right child. 
                    } /* End of if condition pre->right == NULL */
                }     /* End of if condition current->left == NULL*/
            }         /* End of while */

            if (v1 != null && v2 != null)  // swap v1 and v2 
            {
                int tmp = v1.val;
                v1.val = v2.val;
                v2.val = tmp;
            }
        }

        /* 
         * Find the inorder predecessor of current 
         * 
         * thought process:
         * start from input node n2, 
         * Go to left child first, and then, go the right continuously, 
         * until the last one, exclude input node - itself (n1), 
         * return the node (n1); 
         * Think in a graph of rightmost node in the binary search tree. 
         * Also, the code will work if the node is set as right child of 
         * its inordre predecessor. 
         * 
         */
        private static TreeNode findTheInorderPredecessorOfCurrent(TreeNode n2)
        {
            TreeNode n1 = n2.left;      // step 1: moving node (n1), go left first step 

            while (n1.right != null && n1.right != n2) // step 2: then, go right continuously;
                // exclude input node itself 
                n1 = n1.right;

            return n1;
        }

        /*
         *  previous -> current node
         *  thought process:
         *  if the current node visited has a not-null previous node, 
         *  then the two values of nodes should be in increasing order 
         *  
         * Base test case: 
         *   tree only have two nodes, switched; 
         *   case A: 
         *      2          1
         *     /    ->    /                               
         *     1         2
         *   case B: 
         *     1           2
         *      \    ->     \
         *      2            1
         *  Manually, walk through the code, make sure that v1 and v2 are correct results. 
         *  
         * input arguments: 
         *     n1 -  previous  -- 
         *     n2 -  current   --
         * output arguments:
         *      v1,       -- viloation node 1
         *      v2,       -- violation node 2 
         *      found     -- usually violation can be found at most twice; first violation, set found = true from false. 
         *  assumption: n2 node is not null
         *  violation facts:
         *  1. first node, it is the one with bigger value, violated; 
         *  but second node, it is the one with smaller value, violated. 
         *  2. sometimes, only one violation catch; like base case A, switch two nodes, only two nodes
         *     in the tree. Tree [2,#,1]
         *  3. sometimes, two violationes catch. 
         *     Tree [2, 3, 1], inorder traversal result is 3, 2, 1, and then, 
         *     first one of viloations is 3, 2, 3>2, the violation one is 3, bigger value;
         *     second one of viloations is 2, 1, 2>1, the violation one is 1, smaller value;
         *     so, 3 and 1 should be swapped back as 1 (2) 3
         */
        private static void violationChecking(TreeNode n1,
                                              TreeNode n2,
                                              ref TreeNode v1,
                                              ref TreeNode v2,
                                              ref bool found)
        {
            if (n1 != null && n1.val > n2.val)  // break "increasing order" principle
            {
                if (!found)
                {
                    v1 = n1;   // bigger value violated - first one always
                    found = true;
                }

                v2 = n2;       // smaller value violated - second one always 
            }
        }

    }
}
