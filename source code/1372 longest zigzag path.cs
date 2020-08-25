using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1372_longest_zigzag_path
{
     public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
          this.val = val;
          this.left = left;
          this.right = right;
      }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// August 25, 2020
        /// I came out two ideas. I need to come out at least two ideas before I write any code.
        /// The first one is to find all paths from root to leaf node, and then search one by one 
        /// longest zigzag path, space is not efficient, need to store all paths. 
        /// I worked on the second idea, it is to preorder traverse the tree, 
        /// for each node, check left or right zig zag path for longest one. 
        /// If it is the left child of it's parent node, do not need to check
        /// right child. Same applies to right child. 
        /// The average time complexity will be O(nlogn), n is total number of 
        /// nodes in the tree, and logn is average height of the tree. 
        /// Space complexity is O(1). No need to store all paths. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int LongestZigZag(TreeNode root)
        {
            if (root == null)
                return 0;

            var longest = 0;

            preorderTraverseTree(root, 2, ref longest);

            return longest;
        }

        /// <summary>
        /// preorder traverse the tree
        /// 0 - is left child
        /// 1 - is right child
        /// 2 - not applied
        /// unit test:
        /// 1. Tree with one node - 0
        /// </summary>
        /// <param name="root"></param>
        /// <param name="longest"></param>
        private void preorderTraverseTree(TreeNode root, int directionToChild, ref int longest)
        {
            if (root == null)
                return;

            // visit current node
            if (directionToChild == 2)
            {
                // go to left and also go to right two directions to find zigzag paths
                var path1 = findDownwardZigzag(root, 0);
                longest = path1 > longest ? path1 : longest;

                var path2 = findDownwardZigzag(root, 1);
                longest = path2 > longest ? path2 : longest;
            }
            else if (directionToChild == 0)
            {
                // go to left downward zigzag                
                var path = findDownwardZigzag(root, 0);
                longest = path > longest ? path : longest;
            }
            else if (directionToChild == 1)
            {
                // go to right downward zigzag
                var path = findDownwardZigzag(root, 1);
                longest = path > longest ? path : longest;
            }            

            preorderTraverseTree(root.left,  0,  ref longest);
            preorderTraverseTree(root.right, 1,  ref longest);
        }

        /// <summary>
        /// direction = 0 - left 
        /// direction = 1 - right 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private int findDownwardZigzag(TreeNode root, int direction)
        {
            var count = direction;
            while ((count % 2 == 0 && root != null && root.left  != null) ||
                   (count % 2 == 1 && root != null && root.right != null))
            {
                if (count % 2 == 0)
                {
                    root = root.left;
                }
                else
                {
                    root = root.right;
                }

                count++;
            }

            return count - direction;
        }
    }
}
