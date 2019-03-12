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
            var result = BstFromPreorder(new int[] { 8, 5, 1, 7, 10, 12 });
        }

        /// <summary>
        /// 2019-03-11
        /// I like to review the code written in the contest and then make some improvements
        /// Try to write simple code. 
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public static TreeNode BstFromPreorder(int[] preorder)
        {
            return preorderTraversal(preorder, 0, preorder.Length - 1);
        }

        /// <summary>
        /// March 11, 2019
        /// based on the code written in the contest, I like to review the code and come out 
        /// the idea to improve the performance. 
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

            var root = new TreeNode(preorder[start]);

            var lastIndex = search(preorder, root.val, start, end);

            root.left  = preorderTraversal(preorder, start + 1,     lastIndex);
            root.right = preorderTraversal(preorder, lastIndex + 1, end);

            return root;
        }

        /// <summary>
        /// design the function to avoid user case -1, not found.         
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="value"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static int search(int[] preorder, int value, int start, int end)
        {
            var lastIndex = start;
            for (int i = start; i <= end; i++)
            {
                var current = preorder[i];
                if (current > value)
                {
                    break;
                }

                lastIndex = i;
            }

            return lastIndex;
        }
    }
}
