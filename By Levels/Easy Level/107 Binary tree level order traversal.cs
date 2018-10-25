using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_107_Binary_tree_level_order_traversal_II
{
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
            RunTestcase();
        }

        public static void RunTestcase()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;

            var bottomUp = LevelOrderBottom(node1);
        }

        public static IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            var bottomUp = new List<IList<int>>();

            if (root == null)
                return bottomUp;

            var visitedStack = new Stack<IList<int>>();
            var queue = new Queue<TreeNode>();

            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelCount = queue.Count;
                var currentLevel = new List<int>();

                for (int i = 0; i < levelCount; i++)
                {
                    var current = queue.Dequeue();
                    currentLevel.Add(current.val);

                    if (current.left != null)
                        queue.Enqueue(current.left);

                    if (current.right != null)
                        queue.Enqueue(current.right);
                }

                visitedStack.Push(currentLevel);
            }

            while (visitedStack.Count > 0)
            {
                bottomUp.Add(visitedStack.Pop());
            }

            return bottomUp;
        }
    }
}