using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _637_average_of_levels_in_binary_tree
{
    class Program
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
        }

        public IList<double> AverageOfLevels(TreeNode root)
        {
            var averages = new List<double>();

            if (root == null)
                return averages;

            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            // push into queue by level 
            while (queue.Count > 0)
            {
                var count = queue.Count;
                double sum = 0;
                for (int i = 0; i < count; i++)
                {
                    var current = queue.Dequeue();
                    sum += current.val;

                    if (current.left != null)
                        queue.Enqueue(current.left);

                    if (current.right != null)
                        queue.Enqueue(current.right);
                }

                averages.Add(sum / count);
            }

            return averages;
        }
    }
}
