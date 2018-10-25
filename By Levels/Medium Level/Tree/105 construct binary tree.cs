using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _105_construct_binary_tree
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

        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null)
                return null;
            if (preorder.Length == 0 || preorder.Length != inorder.Length)
                return null;

            return buildTreeHelper(preorder, inorder, 0, preorder.Length - 1, 0);
        }
        /// <summary>
        /// use a test case to help me to figure out the recursive call detail and also design detail
        /// 
        ///   3
        ///  / \
        /// 9  20
        ///   /  \
        ///   15  7
        /// preorder = [3, 9, 20, 15, 7]
        /// inorder  = [9, 3, 15, 20, 7]
        /// Also I like to desing as a few elements in the array as possible
        /// 
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <param name="pStart"></param>
        /// <param name="pEnd"></param>
        /// <param name="inorderStart"></param>
        /// <returns></returns>
        private static TreeNode buildTreeHelper(int[] preorder, int[] inorder, int pStart, int pEnd, int inorderStart)
        {
            if (pStart > pEnd || pStart >= preorder.Length)
            {
                return null;
            }

            var rootValue = preorder[pStart];

            var root = new TreeNode(rootValue);

            var length = preorder.Length;

            // find the left substree range
            var rootIndex = -1;
            for (int i = inorderStart; i < length; i++)
            {
                if (inorder[i] == rootValue)
                {
                    rootIndex = i;
                    break;
                }
            }

            var numberNodes = rootIndex - inorderStart; // left subtree
            var preorderLastOne = pStart + numberNodes;

            root.left = buildTreeHelper(preorder, inorder, pStart + 1, preorderLastOne, inorderStart);
            root.right = buildTreeHelper(preorder, inorder, preorderLastOne + 1, pEnd, rootIndex + 1);

            return root;
        }
    }
}
