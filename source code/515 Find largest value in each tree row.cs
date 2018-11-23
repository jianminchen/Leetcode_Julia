using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _515_Find_largest_value_in_each_tree_row
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
        /// Apply Queue to level by level tree traveral, and calculate and save max value for each level
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<int> LargestValues(TreeNode root)
        {
            if (root == null)
                return new List<int>();

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            var maxList = new List<int>(); 

            while (queue.Count > 0)
            {
                var levelSize = queue.Count;

                var maxValue = Int32.MinValue;
                for (int i = 0; i < levelSize; i++)
                {
                    var node = queue.Dequeue();

                    maxValue = node.val > maxValue ? node.val : maxValue;

                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }

                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }

                maxList.Add(maxValue); 
            }

            return maxList;
        }
    }
}
