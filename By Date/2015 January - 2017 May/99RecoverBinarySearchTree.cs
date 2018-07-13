using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _99RecoverBinarySearchTree
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
         * problem statement:
         * Two elements of a binary search tree (BST) are swapped by mistake.

           Recover the tree without changing its structure.

           Note:
           A solution using O(n) space is pretty straight forward. Could you devise
         * a constant space solution?
         */
        /*
         * Reference: 
         * http://fisherlei.blogspot.ca/2012/12/leetcode-recover-binary-search-tree.html
         * 
         * Analysis from the above blog:
         * O(1)的解法就是
            Inorder traverse, keep the previous tree node,
            Find first misplaced node by
            if ( current.val < prev.val )
               Node first = prev;

            Find second by
            if ( current.val < prev.val )
               Node second = current;

            After traversal, swap the values of first and second node. Only need two pointers, 
         *  prev and current node. O(1) space.
         *  
         * 但是这个解法的前提是Traverse Tree without Stack. 中序遍历如何才能不使用栈。这里就要引入
         * 一个概念， Threaded Binary Tree。So, we first create links to Inorder successor and 
         * print the data using these links, and finally revert the changes to restore 
         * original tree.
         * 
         * 1. Initialize current as root 
           2. While current is not NULL
               If current does not have left child
                  a) Print current’s data
                  b) Go to the right, i.e., current = current->right
               Else
                  a) Make current as right child of the rightmost node in current's left subtree
                  b) Go to this left child, i.e., current = current->left
         * 那么，基于这个双指针遍历，可以把错置节点的判断逻辑加进去，就可以完美的在O(1)空间内，
         * 完成树的重构。

        
           Continue to update the code。增加了一个pointer -- parent来记录上一个访问节点。
         * 整个遍历过程中，使用（parent->val > current->val）来寻找违规节点，但是区别是，
         * 要获取第一次violation的parent和第二次violation的current，然后交换。
         * 
         * Julia's comment: 
         * 1. Read "Threaded Binary Tree" later after playing with source code; coding 
         * first, and then, expand the knowledge. 
         * 2. Try the code first.
         * 3. online judge:
         * 1916 / 1916 test cases passed.
            Status: Accepted
            Runtime: 224 ms
         */
        public static void recoverTree(TreeNode root)
        {
            TreeNode f1 = null,     // two vilation nodes, f1 and f2 
                     f2 = null;

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
                    if (pa != null && pa.val > ith.val)  // ?
                    {
                        if (!found)
                        {
                            f1 = pa;
                            found = true;
                        }

                        f2 = ith;
                    }

                    pa = ith;         // recover phase, go to next node; no left, then, go to the right. 
                    ith = ith.right;
                }
                else
                {
                    /* Find the inorder predecessor of current */
                    pr = ith.left;
                    while (pr.right != null && pr.right != ith)
                        pr = pr.right;

                    /* Make current as right child of its inorder predecessor */
                    if (pr.right == null)
                    {
                        pr.right = ith;
                        ith = ith.left;   
                    }

                    /* Revert the changes made in if part to restore the original
                    tree i.e., fix the right child of predecssor */
                    else
                    {
                        pr.right = null;

                        if (pa.val > ith.val)
                        {
                            if (!found)
                            {
                                f1 = pa;
                                found = true;
                            }

                            f2 = ith;
                        }

                        pa = ith;
                        ith = ith.right;
                    } /* End of if condition pre->right == NULL */
                } /* End of if condition current->left == NULL*/
            } /* End of while */

            if (f1 != null && f2 != null)
            {
                int tmp = f1.val;
                f1.val = f2.val;
                f2.val = tmp;
            }
        }

        /*
         * Reference: 
         * http://fisherlei.blogspot.ca/2012/12/leetcode-recover-binary-search-tree.html
         * 
        *  Function to traverse binary tree without recursion and without stack 
         */
        ArrayList inorderTraversal(TreeNode root)
        {
           ArrayList result = new ArrayList();  
           TreeNode  c,    // c - current 
                     pre;

           if(root == null)
                return result;

           c = root;
           while(c != null)
           {                
                 if(c.left == null)
                 {
                        result.Add(c.val);
                        c = c.right;     
                 }   
                 else
                 {
                        /* Find the inorder predecessor of current */
                        pre = c.left;
                        while(pre.right != null && pre.right != c)
                               pre = pre.right;

                        /* Make current as right child of its inorder predecessor */
                        if(pre.right == null)
                        {
                               pre.right = c;
                               c = c.left;
                        }
                   
                        /* Revert the changes made in if part to restore the original
                     tree i.e., fix the right child of predecssor */  
                        else
                        {
                               pre.right = null;
                               result.Add(c.val);
                               c = c.right;     
                        } /* End of if condition pre->right == NULL */
                } /* End of if condition current->left == NULL*/
             } /* End of while */

            return result;
        }
    }
}
