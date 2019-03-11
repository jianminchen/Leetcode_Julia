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
        /// the code is based on the following code:
        /// 
        /// </summary>
        /// <param name="preorder"></param>
        /// <returns></returns>
        public static TreeNode BstFromPreorder(int[] preorder)
        {
            return preorderTraversal(preorder, new List<int>(preorder));
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
        private static TreeNode preorderTraversal(int[] preorder, IList<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return null;
            }

            var rootValue = numbers[0];

            var root = new TreeNode(rootValue);

            var leftList  = new List<int>();
            var rightList = new List<int>();

            for (int i = 1; i < numbers.Count; i++)
            {
                var current = numbers[i];
                if (current < rootValue)
                {
                    leftList.Add(current);
                }
                else
                {
                    rightList.Add(current);
                }
            }
                
            root.left  = preorderTraversal(preorder, leftList);
            root.right = preorderTraversal(preorder, rightList);

            return root;
        }
    }
}
