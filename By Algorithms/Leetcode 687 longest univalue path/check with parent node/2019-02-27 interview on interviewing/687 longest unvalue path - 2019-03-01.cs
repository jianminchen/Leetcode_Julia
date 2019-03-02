using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_longest_univalue_path___recursive_solution
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
            var node4c = new TreeNode(4);
            var node4a = new TreeNode(4);
            var node4b = new TreeNode(4);

            node4c.left  = node4a;
            node4c.right = node4b;

            var result = LongestUnivaluePath(node4c);
        }

        /// <summary>
        /// code is based on Feb. 27 interview on interviewing.io
        /// post order traveral
        ///      4c
        ///    /   \
        ///   4a   4b
        /// the longest univale path 
        ///      4c-0
        ///    /    \
        ///   4a-1   4b-1
        /// cross path for each node
        ///      4c-0-2
        ///    /       \
        ///   4a-1-0   4b-1-0
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int LongestUnivaluePath(TreeNode root)
        {
            if (root == null)
                return 0;

            int maxLeftSubtree  = LongestUnivaluePath(root.left);
            int maxRightSubtree = LongestUnivaluePath(root.right);

            // root node
            int countLeft  = getMaxCount(root.left, root.val);
            int countRight = getMaxCount(root.right, root.val);
            
            // cross path can be illustrated using example tree with 4a, 4b, 4c three nodes.
            return Math.Max(Math.Max(maxLeftSubtree, maxRightSubtree), countLeft + countRight);
        }
        
        /// <summary>
        /// use post order traversal, check value compared to parent node's value
        /// longest univalue path from root node to leaf node, cross path is not included. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="parentValue"></param>
        /// <returns></returns>
        private static int getMaxCount(TreeNode root, int parentValue)
        {
            if (root == null)
            {
                return 0;
            }

            if (root.val == parentValue)
            {
                var left  = getMaxCount(root.left,  root.val);
                var right = getMaxCount(root.right, root.val);

                return 1 + Math.Max(left, right); // count edge - 1, stands for edge from root to parent node
            }

            return 0; 
        }
    }
}
