using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_B
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
        /// code review on May 7, 2019
        /// Leetcode 236 lowest common ancestor in binary tree
        /// assumptions:
        /// 1. All of the nodes' values will be unique.
        /// 2. p and q are different and both values will exist in the binary tree.
        /// 
        /// Use post order traversal in the order of left, right, root node. Time complexity will be O(N). 
        /// It is also most time efficient solution, bottom up solution. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null)
                return null;

            // recursive function - find any node in p and q
            if (root == p || root == q)
                return root;

            var left = LowestCommonAncestor(root.left, p, q);
            var right = LowestCommonAncestor(root.right, p, q);

            /* case: left subtree one node is found, right subtree one node is found
             * We can argue that two nodes are found in the tree with root node root. 
             * Also the root node is the parent node. 
            */
            if (left != null && right != null)
                return root;

            /*
             * It takes two steps to reason in the following: 
             * Remember that now the case is left == null || right == null. At least one of return is null. 
             */
                            
             /* 
               if one node is found in left subtree, then the other node may be in the subtree of left node or it is not in. 
             * Since right == null, the other node is not in right subtree. 
             * So left node is the lowest common ancestor, since the other node is in the subtree of left node.            
             */
            if (left != null)
            {
                return left;
            }

            if (right != null)
            {
                return right;
            }

            return null;
        }
    }
}
