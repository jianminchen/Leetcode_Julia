using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _814_binary_tree_pruning
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

        public TreeNode PruneTree(TreeNode root)
        {
            if (root == null)
                return root;

            var value = root.val;
            var isZero = value == 0;
            if (isZero && root.left == null && root.right == null)
                return null;

            var rootLeft = PruneTree(root.left);
            var rootRight = PruneTree(root.right);

            if (isZero && rootLeft == null && rootRight == null)
                return null;
            root.left  = rootLeft;
            root.right = rootRight;

            return root; 
        }
    }
}
