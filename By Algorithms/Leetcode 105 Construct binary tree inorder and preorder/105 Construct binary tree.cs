using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _105_preorder_and_inorder_Contruct_binary_tree
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
        /// August 28, 2020
        /// The idea is to put inorder traversal list into a hashmap, so lookup can be O(1) time complexity;
        /// Just apply recursive function to solve the problem, each time the root node can be found 
        /// from the first node in preorder traversal list. 
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="inorder"></param>
        /// <returns></returns>
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder == null || inorder == null || preorder.Length != inorder.Length ||
               preorder.Length == 0)
            {
                return null;
            }

            var map = new Dictionary<int, int>();
            var inLength = inorder.Length;
            for (int i = 0; i < inLength; i++)
            {
                map.Add(inorder[i], i);
            }

            return runHelper(preorder, 0, preorder.Length - 1, inorder, 0, inorder.Length - 1, map);
        }

        /// <summary>
        /// Recursive function, each step one node is solved in binary tree 
        /// </summary>
        /// <param name="preorder"></param>
        /// <param name="preStart"></param>
        /// <param name="preEnd"></param>
        /// <param name="inorder"></param>
        /// <param name="inStart"></param>
        /// <param name="inEnd"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        private TreeNode runHelper(int[] preorder, int preStart, int preEnd, 
            int[] inorder, int inStart, int inEnd, Dictionary<int, int> map)
        {
            if (preStart > preEnd)
            {
                return null;
            }

            var rootValue = preorder[preStart];
            var root = new TreeNode(rootValue);

            var rootIndex = map[rootValue];
            // calculate left subtree's length using inorder list
            var leftSubTree  = rootIndex - inStart;
            var rightSubTree = inEnd - rootIndex; 

            root.left = runHelper(preorder, preStart + 1, preStart + leftSubTree, 
                                  inorder,  inStart,      inStart + leftSubTree - 1, map);
            root.right = runHelper(preorder, preStart + leftSubTree + 1, preEnd,
                                  inorder,   rootIndex + 1, inEnd, map);
            return root; 
        }
    }
}
