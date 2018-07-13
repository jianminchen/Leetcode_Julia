using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowestCommonAncestorBSearchTree
{
    class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            left = null;
            right = null;
            val = x;
        }
    };

    class Program
    {
        static void Main(string[] args)
        {
        }

        /*
        * Problem statement: 
        * 
        * source code from blog:
       http://articles.leetcode.com/2011/07/lowest-common-ancestor-of-a-binary-search-tree.html
        * analysis from the blog:
        * There’s only four cases you need to consider.

          1. Both nodes are to the left of the tree.
          2. Both nodes are to the right of the tree.
          3. One node is on the left while the other is on the right.
        * 4. When the current node equals to either of the two nodes, this node must be the LCA too.
        * 
        * The run time complexity is O(h), where h is the height of the BST
        * 
        * julia's comment: 
        * 1. convert C code to C# code 
        */
        public static TreeNode LCA(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
                return null;

            if (Math.Max(p.val, q.val) < root.val)
                return LCA(root.left, p, q);
            else if (Math.Min(p.val, q.val) > root.val)
                return LCA(root.right, p, q);
            else
                return root;
        }

    }
}
