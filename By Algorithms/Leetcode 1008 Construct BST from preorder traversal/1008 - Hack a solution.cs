using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_1008
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = BstFromPreorder(new int[]{8, 5, 1, 7, 10, 12});
        }

        /// <summary>
        /// the code is based on the following code:
        /// 
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public static TreeNode BstFromPreorder(int[] preorder)
        {
            return preorderTraversal(preorder, 0, preorder.Length - 1);
        }

        /// <summary>
        /// March 11, 2019
        /// How to hack a solution? 
        /// It is the difference between 3 minutes and 52 minutes. Ten times more efficient problem solving. 
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static TreeNode preorderTraversal(int[] preorder, int start, int end)
        {
            if (start >= preorder.Length || start > end)
            {
                return null;
            }

            var rootValue = preorder[start];          

            var root = new TreeNode(rootValue);

            var lastOne = start; 
            for (int i = start; i <= end; i++)
            {
                var current = preorder[i];
                if (current > rootValue)
                {
                    break;
                }

                lastOne = i;
            }

            // Hack a solution in less than five minutes
            // if lastOne < start + 1, then there is no left child. 
            // There are more than one choices, find lastOne in the left child, or find the first one in right child
            // Left child may be missing, lastOne is set to start as default value. Fall through the code on line 46 to figure out
            root.left  = preorderTraversal(preorder, start + 1,   lastOne);
            root.right = preorderTraversal(preorder, lastOne + 1, end);

            return root;
        }        
    }
}
