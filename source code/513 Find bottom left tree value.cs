using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _513_Find_bottom_left_tree_value
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
        /// Apply Queue to level by level tree traveral, and keep update leftmost node for each level;
        /// last level leftmost value will be saved.
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int FindBottomLeftValue(TreeNode root)
        {
            if (root == null)
                return -1;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var leftMost = root.val; 
            while (queue.Count > 0)
            {
                var levelSize = queue.Count;                

                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();

                    if (i == 0)
                    {
                        leftMost = node.val;
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
            }

            return leftMost;
        }
    }
}
