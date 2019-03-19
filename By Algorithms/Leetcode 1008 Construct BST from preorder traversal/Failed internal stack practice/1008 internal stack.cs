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
        /// linear solution
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public static TreeNode BstFromPreorder(int[] preorder)
        {
            var min = int.MinValue;
            var max = int.MaxValue;
            int index = 0; 

            return preOrderTraversal(preorder, min, max, ref index );
        }

        /// <summary>
        /// code review March 15, 2019
        /// linear solution - preorder traversal
        /// using internal stack
        /// this is not working...
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static TreeNode preOrderTraversal(int[] preorder, int min, int max, ref int index)
        {
            if (min > max || index >= preorder.Length || !(preorder[index] < max && preorder[index] > min))
            {
                return null;
            }

            var current = preorder[index];
            var root = new TreeNode(current);
            var nextIndex = index + 1;

            root.left  = preOrderTraversal(preorder, min,     current, ref nextIndex);        
            root.right = preOrderTraversal(preorder, current, max,     ref nextIndex);

            return root;
        }
    }
}
