using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_687_longest_univalue_path
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

        public static int longestPath = 0; 
        public int LongestUnivaluePath(TreeNode root)
        {
            longestPath = 0;

            preorderTraversal(root,new int[]{-1, -1});

            return longestPath;
        }
        /// <summary>
        /// design has a flaw
        /// - longest path may go through the root node of tree
        /// -- left path + root + right path
        /// </summary>
        /// <param name="root"></param>
        /// <param name="currentCount"></param>
        private static void preorderTraversal(TreeNode root, int[] currentCount)
        {
            if (root == null)
            {
                updateLongestpath(currentCount);
                return;
            }

            var current = root.val;

            var empty = currentCount[1] == -1;
            var sameNumber = !empty && currentCount[0]  == current; 

            if(empty)
            {
                currentCount = new int[] { current, 1 };                
            }
            else if(sameNumber)
            {
                currentCount[1]++;
            }
            else
            {
                updateLongestpath(currentCount);
                currentCount = new int[] {current, 1 };
            }

            preorderTraversal(root.left, currentCount);
            preorderTraversal(root.right, currentCount);
        }

        private static void updateLongestpath(int[] currentCount)
        {
            if (currentCount[1] != -1)
                longestPath = Math.Max(longestPath, currentCount[1] - 1);
        }
    }
}
