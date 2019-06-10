using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _687_longest_univalue_path_V
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
        /// practice on 2019-02-26
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestUnivaluePath(TreeNode root)
        {            
            int crossPath = 0;
            postOrderTraversalCalculatePath(root, ref crossPath);

            return crossPath;
        }

        /// <summary>
        /// post order traversal
        /// - make sure that every node is traversed
        /// - post order traversal 
        /// - recursive function's return value is defined as longest univalue path
        ///   from the root node to its leaf node. Not cross path.
        /// - recursive function counts edge, not nodes
        /// </summary>
        /// <param name="root"></param>
        private static int postOrderTraversalCalculatePath(TreeNode root, ref int crossPath)
        {
            if (root == null)
                return 0;

            // post order - left, right, root 
            var left  = postOrderTraversalCalculatePath(root.left,  ref crossPath);
            var right = postOrderTraversalCalculatePath(root.right, ref crossPath);
            
            // root node handling 
            var currentMax = 0;
            var currentMaxCrossRoot = 0;
            var rootVal = root.val;
                            
            if (root.left != null && rootVal == root.left.val)
            {
                currentMax = left + 1;
                currentMaxCrossRoot = left + 1;
            }            

            // root - Need to calculate the maximum path cross the root                            
            if (root.right != null && rootVal == root.right.val)
            {
                currentMax = Math.Max(currentMax, right + 1);
                currentMaxCrossRoot += right + 1;
            }            

            crossPath = Math.Max(crossPath, currentMaxCrossRoot);
            return currentMax;
        }
    }
}
