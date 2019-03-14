using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_1008_linear_solution
{
    public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = BstFromPreorder(new int[]{8,5, 1, 7, 10, 12}); 
        }

        /// <summary>
        /// the code is based on 
        /// https://leetcode.com/problems/construct-binary-search-tree-from-preorder-traversal/discuss/252719/C%2B%2B-iterative-O(n)-solution-using-decreasing-stack
        /// Maintain a decreasing stack 
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public static TreeNode BstFromPreorder(int[] preorder)
        {
            var dummyRoot = new TreeNode(int.MaxValue);

            var stack = new Stack<TreeNode>();

            stack.Push(dummyRoot);

            foreach (var item in preorder)
            {
                var current = new TreeNode(item);
                TreeNode node = null;

                while (stack.Peek().val < item)
                {
                    node = stack.Pop();
                }

                if (node != null)
                {
                    node.right = current;
                }
                else
                {
                    var top = stack.Peek();
                    top.left = current; 
                }

                stack.Push(current); 
            }

            return dummyRoot.left; 
        }
    }
}
