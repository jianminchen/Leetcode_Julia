using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _998_Maximum_binary_tree_II
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

        public TreeNode InsertIntoMaxTree(TreeNode root, int val)
        {
            if (root == null)
                return new TreeNode(val);

            var current = root.val;
            if (val > current)
            {
                var existing = root.val;
                var newRoot = new TreeNode(val);
                newRoot.left = root;

                return newRoot;
            }
            else
            {
                root.right = InsertIntoMaxTree(root.right, val);

                return root;
            }
        }
    }
}
