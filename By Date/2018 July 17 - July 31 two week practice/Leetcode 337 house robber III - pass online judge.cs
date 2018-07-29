using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_337_House_robber_III
{
    /// <summary>
    /// Leetcode 337 - house robber III
    /// </summary>
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
        }

        public static int Rob(TreeNode root)
        {
            if (root == null)
                return 0;            

            var values = robCalculate(root);

            return Math.Max(values[0], values[1]);
        }

        /// <summary>
        /// I failed the test case with a tree only having left child. 
        ///       4
        ///      /
        ///     1
        ///    /
        ///   2
        ///  /
        ///  3
        /// so I added the code from line 62 to line 65
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static int[] robCalculate(TreeNode root)
        {
            if (root == null)
                return new int[2]{0,0};

            var val = root.val;

            var left = robCalculate(root.left);
            var right = robCalculate(root.right);

            // 0 - include root node, 1 - not include root node
            var includeRoot = val + left[1] + right[1];
            var options = new int[]{left[0] + right[0], 
                left[0] + right[1],
                left[1] + right[0],
                left[1] + right[1]};

            var excludeRoot = options.Max();

            return new int[] { includeRoot, excludeRoot };
        }
    }
}
