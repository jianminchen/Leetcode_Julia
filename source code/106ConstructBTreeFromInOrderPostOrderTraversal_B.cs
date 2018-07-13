using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _106ConstructBTreeFromInOrderPostOrderTraversal_B
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

    public class Range
    {
        public int start;
        public int end;

        public int getLength()
        {
            return end - start + 1; 
        }

        public Range(int s, int e)
        {
            start = s;
            end = e; 
        }
    }
    /*
         * Leetcode: 
         * 106 Construct Binary Tree from Inorder and Post order traversal 
         * 
         * code reference: 
         * http://siddontang.gitbooks.io/leetcode-solution/content/tree/construct_binary_tree.html
         * 
     *     julia's C# implementation: 
     *     https://github.com/jianminchen/Leetcode_C-/blob/master/106ConstructuBTreeFromInorderPostOrderTraversal.cs
     */
    class Program
    {
        static void Main(string[] args)
        {
        }

        static Hashtable htable = new Hashtable();

        public static TreeNode buildTree(int[] inorder, int[] postorder)
        {
            int p_l = postorder.Length;
            if (p_l == 0)
            {
                return null;
            }

            int i_l = inorder.Length;
            for (int i = 0; i < i_l; i++)
            {
                htable[inorder[i]] = i;
            }

            return build(inorder,   new Range(0, i_l - 1),
                         postorder, new Range(0, p_l - 1));
        }

        /*
         *     
                        
                        1
                --------|-------
                2               3
            ----|----       ----|----
            4       5       6       7
         
        preorder traversal:   1245367
        inorder traversal:    4251637
        postorder traversal:  4526731
         * 
         * code reference: 
         * http://siddontang.gitbooks.io/leetcode-solution/content/tree/construct_binary_tree.html
         * 
         * Julia's comment: 
           practice the partition methods 
         * 
         * 2. online judge:
         *  202 / 202 test cases passed.
            Status: Accepted
            Runtime: 192 ms
         */
        public static TreeNode build(int[] inorder, Range iR,
            int[] postorder, Range pR)
        {
            if (iR.start > iR.end || pR.start > pR.end)
            {
                return null;
            }

            int lastOne = pR.end;
            TreeNode root = new TreeNode(postorder[lastOne]);

            int v = postorder[lastOne];              // v - root value 
            int p = (int)htable[v];             // p - root position in inorder traversal array 

            int len = p - iR.start;                 // count - the size of left subtree, how many nodes 

            ArrayList l1 = partitionByMidPoint(iR, p);
            ArrayList l2 = partitionByLength(pR, len); 


            root.left = build(inorder, (Range)l1[0], postorder, (Range)l2[0]);

            root.right = build(inorder, (Range)l1[1], postorder, (Range)l2[1]);

            return root;
        }

        /*
         * 09/12/2015
         *  partition the interval to two, one is left side of mid position, another is right side
         *  assume r.start <= mid <= r.end
         *  
         * this partition applies the inorder traversal array 
         * 09/13/2015 
         * After all the code is done, and then, thought about, add this additional note to help myself training better, 
         * for next time to review my code. 
         * 
         * inorder traversal array: Left subtree, Root Node, Right subtree
         * so, if the root node position can be identified, then two subtree can be seperated by root node. 
         */ 
        public static  ArrayList partitionByMidPoint(Range r, int mid)
        {
            ArrayList l = new ArrayList();

            l.Add(new Range(r.start, mid - 1));
            l.Add(new Range(mid + 1, r.end));

            return l; 
        }

        /* 09/12/2015
         * partition the interval to two, first interval length is input argument: len, 
         * second one is the rest part, extra last one 
         * 
         * this partition is customized for post order traversal array. 
         * 09/13/2015
         * add one more note to help:
         * Post order traversal array: Left subtree, right subtree, Root node
         * so partition them to add left subtree, right subtree to the list, 
         * only if the length of left subtree is known, then, partition can be done. 
         */
        public static ArrayList partitionByLength(Range r, int len)
        {
            ArrayList l = new ArrayList();

            l.Add(new Range(r.start, r.start + len - 1));
            l.Add(new Range(r.start + len, r.end - 1));

            return l; 
        }
    }
}
