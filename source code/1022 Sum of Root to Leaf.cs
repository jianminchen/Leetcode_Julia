using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1022
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

        public int SumRootToLeaf(TreeNode root)
        {
            long sum = 0;
            preorderTraversal(root, 0, ref sum);

            return (int)sum;
        }

        private static void preorderTraversal(TreeNode root, long prefix, ref long sum)
        {
            long module = 1000000000 + 7;

            long current = ((prefix * 2) % module + (long)root.val) % module;

            if (root.left == null && root.right == null)
            {

                sum = (sum + current) % module;

                return;
            }

            if (root.left != null)
            {
                preorderTraversal(root.left, current, ref sum);
            }

            if (root.right != null)
            {
                preorderTraversal(root.right, current, ref sum);
            }
        }
    }
}
