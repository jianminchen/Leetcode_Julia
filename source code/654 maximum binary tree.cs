using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _654_Maximum_binary_tree
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

        public TreeNode ConstructMaximumBinaryTree(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return null;

            return workOnBinaryTree(nums, 0, nums.Length - 1);
        }

        private static TreeNode workOnBinaryTree(int[] numbers, int start, int end)
        {
            if(start > end)
                return null;

            int maxIndex = getIndex(numbers, start, end);
            var root = new TreeNode(numbers[maxIndex]); 
            root.left  = workOnBinaryTree(numbers, start,        maxIndex - 1);
            root.right = workOnBinaryTree(numbers, maxIndex + 1, end);

            return root; 
        }

        private static int getIndex(int[] numbers, int start, int end)
        {
            var maxValue = numbers[start];
            var maxIndex = start; 
            for (int i = start + 1; i <= end; i++)
            {
                var current = numbers[i];
                if (current > maxValue)
                {
                    maxValue = current;
                    maxIndex = i; 
                }
            }

            return maxIndex;
        }
    }
}
