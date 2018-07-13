using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode333_LargestBSTSubtree
{
    /// <summary>
    /// March 14, 2018
    /// code practice - 
    /// source code is based on 
    /// http://www.cnblogs.com/grandyang/p/5188938.html
    /// </summary>
    class Program
    {
        class TreeNode{
            public int      Value {get; set;}
            public TreeNode Left  {get; set;}
            public TreeNode Right {get; set;}

            public TreeNode(int number)
            {
                Value = number;
            }
        }

        static void Main(string[] args)
        {
            runTestcase1(); 
        }

        public static void runTestcase1()
        {
            var node10 = new TreeNode(10);
            var node5  = new TreeNode(5);

            node5.Left  = new TreeNode(1);
            node5.Right = new TreeNode(8);

            var node15 = new TreeNode(15);
            
            node10.Left  = node5;
            node10.Right = node15;

            node15.Right = new TreeNode(7);

            var result = largestBSTSubtree(node10);
            Debug.Assert(result == 3); 
        }

        static int largestBSTSubtree(TreeNode root) {
            int res = 0;
            int min = int.MinValue;
            int max = int.MaxValue;

            bool d = isValidBST(root, ref min, ref max, ref res);

            return res;
        }

        /// <summary>
        /// code review on March 14, 2018
        /// optimal solution:
        /// Time complexity: O(N)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="res"></param>
        /// <returns></returns>
        static bool isValidBST(TreeNode root, ref int min, ref int max, ref int res)
        {
            if (root == null)
            {
                return true;
            }

            int left_n   = 0;
            int right_n  = 0;

            int left_min = int.MinValue;
            int left_max = int.MaxValue;

            int right_min = int.MinValue;            
            int right_max = int.MaxValue;

            var left  = isValidBST(root.Left,  ref left_min,  ref left_max,  ref left_n);
            var right = isValidBST(root.Right, ref right_min, ref right_max, ref right_n);

            if (left && right) {
                var leftNode  = root.Left;
                var rightNode = root.Right;
                var value = root.Value;

                if ((leftNode == null || value > left_max) && (rightNode == null || value < right_min))
                {
                    res = left_n + right_n + 1;

                    min = leftNode  != null ? left_min  : value;
                    max = rightNode != null ? right_max : value;

                    return true;
                }
            }

            res = Math.Max(left_n, right_n);

            return false;
        }
    }
}
