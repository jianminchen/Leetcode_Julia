using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _865_smalls_subtree_with_all_the_deepest_nodes
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

        public TreeNode SubtreeWithAllDeepest(TreeNode root)
        {
            if (root == null)
                return null;

            var depthLeft = getDepth(root.left);
            var depthRight = getDepth(root.right);
            if (depthLeft == depthRight)
                return root;
            else if (depthLeft > depthRight)
            {
                return SubtreeWithAllDeepest(root.left);
            }
            else
            {
                return SubtreeWithAllDeepest(root.right);
            }
        }

        private static int getDepth(TreeNode root)
        {
            if (root == null)
                return 0;

            return 1 + Math.Max(getDepth(root.left), getDepth(root.right));
        }
    }
}
