using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _199_binary_tree_right_side_view
{
     public class TreeNode {
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
        /// level by level order traversal, record the last node in each level.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> RightSideView(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var lastNodes = new List<int>();

            while (queue.Count > 0)
            {
                var levelCount = queue.Count;
                var lastNode = new TreeNode(-1);
                for (int i = 0; i < levelCount; i++)
                {
                    var node = queue.Dequeue();
                    if (i == levelCount - 1)
                    {
                        lastNode = node;
                    }

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                lastNodes.Add(lastNode.val); 
            }

            return lastNodes;
        }
    }
}
