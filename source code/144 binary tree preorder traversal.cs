using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _144_binary_tree_preorder_traversal
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
            RunTestcase1(); 
        }

        public static void RunTestcase1()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4); 

            node1.left  = node2;
            node1.right = node3;
            node3.left  = node4;

            var result = PreorderTraversal(node1); 
        }

        /// <summary>
        /// use iterative solution
        /// depth first search, push nodes into stack - left child
        /// - mark visited nodes for those left child node
        /// - continue to search its right child, using same process
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> PreorderTraversal(TreeNode root)
        {
            if (root == null)
            {
                return new List<int>(); 
            }

            var visited = new HashSet<TreeNode>();
            var stack = new Stack<TreeNode>();

            var nodes = new List<int>(); 
            
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                var secondVisit = visited.Contains(node);

                var iterate = node;
                if (secondVisit)
                {
                    iterate = node.right;
                }
                else
                {
                    visited.Add(node);
                }

                // start from root node, go left until leaf node
                while (iterate != null)
                {
                    nodes.Add(iterate.val);
                    visited.Add(iterate);

                    stack.Push(iterate);
                    iterate = iterate.left;
                }
            }

            return nodes; 
        }
    }
}
