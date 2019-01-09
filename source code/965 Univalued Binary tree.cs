using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _965_Univalued_Binary_tree
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

        public bool IsUnivalTree(TreeNode root)
        {
            if (root == null)
                return true;

            if (root.left == root.right && root.left == null)
                return true;

            return (root.left == null || (root.val == root.left.val && IsUnivalTree(root.left))) &&
                   (root.right == null || (root.val == root.right.val && IsUnivalTree(root.right)));
        }
    }
}
