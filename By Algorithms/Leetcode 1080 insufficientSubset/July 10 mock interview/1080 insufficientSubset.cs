using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1080_sufficient_node
{
    class Program
    {
        static void Main(string[] args)
        {
            var root = new TreeNode(10);
            root.left = new TreeNode(5);
            root.right = new TreeNode(10);

            var result = SufficientSubset(root, 21);
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left, right;

            public TreeNode(int value)
            {
                val = value; 
            }
        }

        public static TreeNode SufficientSubset(TreeNode root, int limit)
        {
            if (root.left == null && root.right == null && root.val < limit)
                return null;

            // preorder traversal the tree and save root to node paths sum into a hashmap
            // int[] first one is sum, second one - 1 - leaf node - 0 - not leaf node
            var map = new Dictionary<TreeNode, int[]>();

            TreeNode parent = null;
            preorderTraversal(root, map, 0);

            // postorder traversal, and then calculate the root to leaf path
            // remove nodes if need
            // leaf node to current node sum
            //  TreeNode parent = null;
            postOrderTraversal(root, map, parent, limit, true);

            if (root.left == null && root.right == null)
                return null;

            return root;
        }

        /// root 1, left -99, right -99, limit 1
        private static void preorderTraversal(
            TreeNode root, 
            Dictionary<TreeNode, int[]> map, 
            int sumRootToP)
        {
            if (root == null)
                return;

            var sum = sumRootToP + root.val; // -99

            var isLeaf = root.left == null && root.right == null; // false

            var value = isLeaf ? 1 : 0;
            map.Add(root, new int[] { sumRootToP + root.val, value }); // {-98, 1}

            preorderTraversal(root.left, map, sum);
            preorderTraversal(root.right, map, sum);
        }

        // root 1, left -99, right -99, limit 1
        private static void postOrderTraversal(
        TreeNode root,
        Dictionary<TreeNode, int[]> rootToPMap,
        TreeNode parent,
        int limit,
        bool isLeft)
        {
            if (root == null)
                return;

            // Left and right
            postOrderTraversal(root.left, rootToPMap, root, limit, true);
            postOrderTraversal(root.right, rootToPMap, root, limit, false);

            // if root node is leaf node
            if (rootToPMap[root][1] == 1)
            {
                var sum = rootToPMap[root][0]; // -98
                if (sum < limit)
                {
                    //leafMap.Add(root, false); // keep the leaf
                    if (parent != null && isLeft)
                    {
                        parent.left = null;
                    }
                    else if (parent != null)
                    {
                        parent.right = null;
                    }
                    else if (parent == null)
                    {
                        root = null;
                    }
                }
            }
            else // not leaf node
            {
                if (root.left == null && root.right == null)
                {
                    if (parent != null)
                    {
                        if (isLeft)
                            parent.left = null;
                        else
                            parent.right = null;
                    }

                    root = null;
                }
            }
        }    
    }
}
