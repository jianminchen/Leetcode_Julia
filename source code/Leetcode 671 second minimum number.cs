using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_671_second_minimum_number
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public int FindSecondMinimumValue(TreeNode root)
        {
            if (root == null)
                return -1;

            var smallestTwo = new int[] { -1, -1 }; // smallest first

            traversePreorder(root, smallestTwo);

            return smallestTwo[1];
        }

        private static void traversePreorder(TreeNode root, int[] smallestTwo)
        {
            if (root == null)
                return;

            var current = root.val;

            var smallest = smallestTwo[0];
            var secondSmallest = smallestTwo[1];

            if (smallest == -1 || current < smallest)
            {
                smallestTwo[0] = current;
                smallestTwo[1] = smallest;
            }
            else if (current != smallest && (secondSmallest == -1 || (current < secondSmallest)))
                smallestTwo[1] = current;

            traversePreorder(root.left, smallestTwo);
            traversePreorder(root.right, smallestTwo);
        }
    }
}
