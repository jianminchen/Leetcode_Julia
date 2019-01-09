using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _145_Binary_tree_postorder_traversal
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
            RunTestcase2(); 
        }

        public static void RunTestcase()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);

            node1.left = node2;
            node2.left = node3;

            var result = PostorderTraversal(node1); 
        }

        public static void RunTestcase2()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);

            node1.left  = node2;
            node2.left  = node3;
            node2.right = node4;
            node4.left  = node5;


            var result = PostorderTraversal(node1);
        }

        /// <summary>
        /// post order traversal - Left, right, root
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<int> PostorderTraversal(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var iterate = root;
            var stack = new Stack<TreeNode>();
            var visited = new HashSet<TreeNode>(); 

            var postOrder = new List<int>(); 

            while (iterate != null)
            {
                stack.Push(iterate);

                iterate = iterate.left;
            }

            while (stack.Count > 0)
            {
                var node = stack.Peek();                

                iterate = node.right;

                if (iterate == null || visited.Contains(iterate))
                {
                    postOrder.Add(node.val);
                    visited.Add(node);
                    stack.Pop();
                }
                else
                {
                    while (iterate != null)
                    {
                        stack.Push(iterate);
                        iterate = iterate.left;
                    }
                }
            }

            return postOrder; 
        }
    }
}
