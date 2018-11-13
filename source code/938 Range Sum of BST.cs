using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _938_Range_Sum_of_BST
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

        public int RangeSumBST(TreeNode root, int L, int R)
        {
            if (root == null)
                return 0;

            var value = root.val;
            if (value >= L && value <= R)
            {
                return value + RangeSumBST(root.left, L, R) + RangeSumBST(root.right, L, R);
            }
            else if (value > R)
            {
                return RangeSumBST(root.left, L, R);
            }
            else
                return RangeSumBST(root.right, L, R);
        }
    }
}
