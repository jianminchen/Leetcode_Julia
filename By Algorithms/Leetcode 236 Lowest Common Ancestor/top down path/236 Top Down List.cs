using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new TreeNode(1);
            var node3 = new TreeNode(3);
            var node5 = new TreeNode(5);
            var node7 = new TreeNode(7);
            var node9 = new TreeNode(9);
            var node11 = new TreeNode(11); 
            var node13 = new TreeNode(13);

            node1.left = node3;
            node1.right = node5;

            node3.left = node7;
            node3.right = node9;
            node7.left = node11;
            node9.right = node13;

            var lca = LowestCommonAncestor(node1, node11, node13);
            Debug.Assert(lca == node3);
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null || p == null || q == null)
            {
                return null; 
            }

            var pathP = new List<TreeNode>();
            var pathQ = new List<TreeNode>(); 

            runPreorderFindP(root, p, pathP);
            runPreorderFindP(root, q, pathQ);

            if(pathP.Count == 0 || pathQ.Count == 0)
            {
                return null;
            }

            var ancestor = root;
            var index = 0; 
            var pLength = pathP.Count; 
            var qLength = pathQ.Count;
            while (index < pLength && index < qLength && pathP[index] == pathQ[index])
            {
                index++; 
            }

            return pathP[index - 1]; 
        }

        /// <summary>
        /// 1. Backtrack is most important technique to practice here.
        /// 2. Design recursive function with bool return, find TreeNode p or not. It is easy to tell.
        /// 2. Use a test case to verify the code
        ///        5
        ///      /  \ 
        ///     11  13
        ///     given root node 5, p value 13
        ///     try to walk through the code, and then track path list
        ///     []->[5]->[5, 11]->[5]->[5,13]-> return true
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool runPreorderFindP(TreeNode root, TreeNode p, List<TreeNode> path)
        {
            if (root == null) // 5
            {
                return false; // it is executed twice, Node11.left, Node11.right
            }

            path.Add(root); // [5] -> [5,11] -> [5, 13]

            if (root == p)
            {
                return true; // Node 13
            }

            var left  = runPreorderFindP(root.left,  p, path); 
            var right = runPreorderFindP(root.right, p, path); 

            if (left || right)  
            {
                return true; // Node 5, right is true
            }

            path.RemoveAt(path.Count - 1); // remove 11 from [5, 11] -> [5]

            return false; // Node 11
        }
    }
}
