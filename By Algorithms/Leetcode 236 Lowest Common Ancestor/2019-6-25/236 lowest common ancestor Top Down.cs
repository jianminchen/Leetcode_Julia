using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor___top_down
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
            var node0 = new TreeNode(0);
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);
            var node8 = new TreeNode(8);

            node3.left = node5;
            node3.right = node1;
            node5.left = node6;
            node5.right = node2;
            node2.left = node7;
            node2.right = node4;
            node1.left = node0;
            node1.right = node8;

            LowestCommonAncestor(node3, node5, node1);
        }

        public static HashSet<TreeNode> path;
        public static TreeNode lowestCommonAncestor;

        /// <summary>
        /// June 25, 2019
        /// Try to apply top down technique 
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            path = new HashSet<TreeNode>();
            lowestCommonAncestor = null;

            preorderTraversal(root, p);
            preorderTraversal(root, q);

            return lowestCommonAncestor;
        }

        private static bool preorderTraversal(TreeNode root, TreeNode p)
        {
            if (root == null || lowestCommonAncestor != null)
                return false;

            // visit root node
            if(root == p)
            {
                if (path.Contains(root))
                {
                    lowestCommonAncestor = root;
                    return false; 
                }
                else
                {
                    path.Add(root);
                }                
            }

            // Left and right
            var left  = preorderTraversal(root.left, p);
            var right = preorderTraversal(root.right, p);

            if (left || right)
            {
                if (path.Contains(root))
                {
                    lowestCommonAncestor = root;
                    return false; 
                }
                else
                {
                    path.Add(root);
                }
            }

            return root == p || left || right; 
        }
    }
}
