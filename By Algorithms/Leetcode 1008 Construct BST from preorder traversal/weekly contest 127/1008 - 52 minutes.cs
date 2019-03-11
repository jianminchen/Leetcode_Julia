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
        }

        /// <summary>
        /// Leetcode 1008
        /// I wrote the solution in the weekly contest 127
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public TreeNode BstFromPreorder(int[] preorder)
        {
            return preorderTraversal(preorder, 0, preorder.Length - 1);
        }

        private static TreeNode preorderTraversal(int[] preorder, int start, int end)
        {
            if (start >= preorder.Length || start > end)
            {
                return null;
            }

            var rootValue = preorder[start];

            if (start == end)
            {
                return new TreeNode(rootValue);
            }

            var root = new TreeNode(rootValue);
            var newStart = start + 1;
            var lastIndex = search(preorder, root.val, newStart, end);
            var missingLeft = lastIndex == -1;

            if (missingLeft)
            {
                root.right = preorderTraversal(preorder, newStart, end);
                return root;
            }

            root.left = preorderTraversal(preorder, newStart, lastIndex);
            root.right = preorderTraversal(preorder, lastIndex + 1, end);

            return root;
        }

        private static int search(int[] preorder, int value, int start, int end)
        {
            for (int i = start; i <= end; i++)
            {
                var current = preorder[i];
                if (current < value && (i == end || preorder[i + 1] > value))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
