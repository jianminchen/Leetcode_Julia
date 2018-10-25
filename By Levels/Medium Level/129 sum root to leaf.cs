using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _129_sum_root_to_leaf_numbers
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x)
            {
                val = x;
            }
        }

        static void Main(string[] args)
        {
        }

        public int SumNumbers(TreeNode root)
        {
            if (root == null)
                return 0;

            return sumNumbersWithPrefix(root, 0);
        }

        private static int sumNumbersWithPrefix(TreeNode root, int prefixSum)
        {
            if (root == null)
                return prefixSum;

            var current = root.val;
            var newPrefixSum = prefixSum * 10 + current;

            if (root.left == null && root.right == null)
                return newPrefixSum;

            var newSum = 0;
            if (root.left != null)
                newSum += sumNumbersWithPrefix(root.left, newPrefixSum);
            if (root.right != null)
                newSum += sumNumbersWithPrefix(root.right, newPrefixSum);

            return newSum;
        }
    }
}
