using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace countNodeWithOneChild
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

        /// <summary>
        /// empty tree - 0
        /// one node tree - 0
        /// one node with one child -> 1
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int CountNodeWithOneChild(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }
            
            // one of them is true. In other words, one child is not empty.
            var hasOneChild = (root.left != null) != (root.right != null);

            var result = CountNodeWithOneChild(root.left) + CountNodeWithOneChild(root.right);
            if (hasOneChild)
                result += 1;
            return result; 
        }
    }
}
