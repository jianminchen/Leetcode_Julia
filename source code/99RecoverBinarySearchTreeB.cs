using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99RecoverBinarySearchTreeB
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
            /*
             * Test case 1:
             */
            TreeNode n1 = new TreeNode(0);
            n1.left = new TreeNode(1);

            //recoverTree(n1);

            TreeNode n2 = new TreeNode(2);
            n2.right = new TreeNode(1);

            recoverTree(n2);

            TreeNode n3 = new TreeNode(4);
            n3.left = new TreeNode(6);
            n3.left.left = new TreeNode(1);
            n3.left.right = new TreeNode(3);

            n3.right = new TreeNode(2);
            n3.right.left = new TreeNode(5);
            n3.right.right = new TreeNode(7);

            //recoverTree(n3); 


        }

        /*
         * Reference: 
         * http://www.jiuzhang.com/solutions/recover-binary-search-tree/
         * 
         * julia's comment:
         * 1. the code could not pass online judge (need to take away static keyword) 
         * 
         *  Input:
                [2,null,1]
                Output:
                [2,null,0]
                Expected:
                [1,null,2]
         *  But, my own test case shows correct. 
         */

        private static TreeNode v1 = null;     // the first violation node 
        private static TreeNode v2 = null;  // the second violation node
        private static TreeNode theLast = new TreeNode(int.MinValue);

        public static void recoverTree(TreeNode root)
        {
            // traverse and get two elements
            traverse(root);
            // swap
            int temp = v1.val;
            v1.val = v2.val;
            v2.val = temp;
        }

        /*
         * julia's comment:
         * the violation in inorder traversal output is not written in most simple form. 
         * Rewrite the second version traverse_B
         */
        private static void traverse(TreeNode t)
        {
            if (t == null)
            {
                return;
            }

            traverse(t.left);


            bool inIncreasingOrder = t.val > theLast.val;
            if (!inIncreasingOrder)  // not in increasing order 
            {
                if (v1 == null)
                {
                    v1 = t;
                    v2 = theLast;   // this is the one - violation one. 
                }
                else
                {
                    v1 = v2;
                    v2 = t;
                }
            }

            theLast = t;
            traverse(t.right);
        }

        /*
         * 
         *  Base test case: 
         *   tree only have two nodes, switched; 
         *   case A: 
         *      2          1
         *     /    ->    /                               
         *     1         2
         *   case B: 
         *     1           2
         *      \    ->     \
         *      2            1
         *      
         violation facts:
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
        private static void traverse_B(TreeNode t)
        {
            if (t == null)
            {
                return;
            }

            traverse(t.left);


            bool inIncreasingOrder = t.val > theLast.val;
            if (!inIncreasingOrder)  // not in increasing order 
            {
                if (v1 == null)
                {
                    v1 = t;    // first violation node, with bigger value                   
                }

                v2 = theLast;  // second violation node, with smaller value 
            }

            theLast = t;
            traverse(t.right);
        }
    }
}