using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1110_delete_nodes_in_forest
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6; 
            node3.right = node7;

            var result = DelNodes(node1, new int[]{3, 5}); 
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        /// <summary>
        /// Use level order traversal or depth first search 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="to_delete"></param>
        /// <returns></returns>
        public static IList<TreeNode> DelNodes(TreeNode root, int[] to_delete)
        {
            if (root == null)
            {
                return new List<TreeNode>(); 
            }

            var nodes = new List<TreeNode>(); 
            var hashSet = new HashSet<int>(to_delete);

            runDFS(root, hashSet, nodes, null);

            return nodes; 
        }

        /// <summary>
        /// Try to cover base case very well
        /// empty tree, tree with one node,
        /// </summary>
        /// <param name="root"></param>
        /// <param name="to_delete"></param>
        /// <param name="nodes"></param>
        /// <param name="parent"></param>
        private static void runDFS(TreeNode root, HashSet<int> to_delete, IList<TreeNode> nodes, TreeNode parent )
        {
            if(root == null)
                return; 

            var isDelete = to_delete.Contains(root.val);
            
            if(parent == null && !isDelete)
            {
                nodes.Add(root); // add a new subtree
            }
            
            if(isDelete)
            {
                if(parent != null && parent.left == root)
                    parent.left = null;
                if(parent != null && parent.right == root)
                    parent.right = null;
            }

            var nextParent = isDelete? null : root; 
            runDFS(root.left, to_delete, nodes, nextParent);
            runDFS(root.right, to_delete, nodes, nextParent);
        }
    }
}
