using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace longest_univalue_path___compare_to_root
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

        int maxCrossPath = 0; // global variable
        public int LongestUnivaluePath(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            maxCrossPath = 0;
            postOrderTraversal(root, root.val);

            return maxCrossPath;
        }

        /// <summary>
        /// using postorder traversal
        /// I like to use binary tree in the following to explain the idea:
        ///   dummy root
        ///        |
        ///        5c
        ///      /   \
        ///      5a    5b
        /// First, we work on recursive function. Every node is to check with its parent value
        /// path value
        /// Post order traversal, bottom up, three steps, 5a, 5b, 5c
        /// step 1:
        ///     dummy root
        ///         | 
        ///         5c
        ///      /     \
        ///      5a-1    5b
        /// step 2:
        ///     dummy root
        ///         | 
        ///         5c
        ///      /     \
        ///      5a-1    5b-1
        /// step 3:
        ///     dummy root
        ///         | 
        ///         5c-0
        ///      /     \
        ///      5a-1    5b-1
        ///      
        /// combination of step 1, 2, 3:
        ///    dummy root
        ///         | 
        ///         5c-0
        ///      /     \
        ///      5a-1    5b-1  
        ///  The above tree left child with node value 5, 1 counts for the edge of the node 5 
        ///  to its parent, in other words, edge from node 5a to 5c;
        ///  likewise the right child. 
        ///  Now the calucation of cross path
        ///    dummy root
        ///         | 
        ///         5c-0-2
        ///      /       \
        ///      5a-1-0    5b-1-0  
        ///  The node 5c's cross path value is 2, since two edges, one is 5a to 5c, and the other is 5b to 5c. 
        /// </summary>
        /// <param name="node"></param>
        /// <param name="parentValue"></param>
        /// <returns></returns>
        private int postOrderTraversal(TreeNode node, int parentValue)
        {
            if (node == null)
            {
                return 0;
            }

            var current = node.val;

            int left  = postOrderTraversal(node.left,  current);
            int right = postOrderTraversal(node.right, current);

            maxCrossPath = Math.Max(maxCrossPath, left + right); // longest univalue path crossing the root

            if (parentValue == node.val)
            {
                return Math.Max(left, right) + 1;
            }

            return 0;
        }
    }
}
