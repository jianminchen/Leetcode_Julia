using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _113_path_sum_II
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

        public IList<IList<int>> PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return new List<IList<int>>();

            var currentSum = new List<int>();
            var paths = new List<IList<int>>();

            pathSumHelper(root, sum, currentSum, paths);

            return paths;
        }

        private static void pathSumHelper(TreeNode root, int sum, IList<int> currentSum, IList<IList<int>> paths)
        {
            if (root == null)
                return;

            var currentValue = root.val;
            currentSum.Add(currentValue);

            if (root.left == null && root.right == null)
            {
                if (sum == currentValue)
                    paths.Add(currentSum);
            }
            else
            {
                pathSumHelper(root.left, sum - currentValue, new List<int>(currentSum), paths);
                pathSumHelper(root.right, sum - currentValue, new List<int>(currentSum), paths);
            }
        }
    }
}
