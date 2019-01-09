using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _958_Check_completeness_of_a_binary_tree___2
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

        public bool IsCompleteTree(TreeNode root)
        {
            int sum = 0;
            int nodeCount = 0;
            FillMap(root, 1, ref sum, ref nodeCount);

            return sum == nodeCount * (nodeCount + 1) / 2;
        }

        private static void FillMap(TreeNode root, int index, ref int sum, ref int nodeCount)
        {
            if (root == null)
            {
                return;
            }

            FillMap(root.left, 2 * index, ref sum, ref nodeCount);
            FillMap(root.right, 2 * index + 1, ref sum, ref nodeCount);

            sum += index;
            nodeCount++;
        }
    }
}
