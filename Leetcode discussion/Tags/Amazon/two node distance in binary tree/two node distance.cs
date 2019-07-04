using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binary_tree_two_node_distance
{
    class Program
    {
        public class TreeNode {
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

            var result = CalculateDistance(node3, node6, node4);
            Debug.Assert(result == 3);

            var result2 = CalculateDistance(node3, node7, node8);
        }

        public static HashSet<TreeNode> nodes = new HashSet<TreeNode>();
        public static Dictionary<TreeNode, int> map = new Dictionary<TreeNode, int>();
        public static int distance = -1;
        public static int countToP = 0; 

        /// <summary>
        /// July 4, 2019
        /// calculate two node's distance in binary tree
        /// write the answer for the post on Leetcode.com
        /// https://leetcode.com/discuss/interview-question/125084/Amazon-Distance-between-2-nodes
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int CalculateDistance(TreeNode root, TreeNode p, TreeNode q)
        {
            nodes.Clear();
            map.Clear();
            distance = -1;            

            postOrderTraversal(root, p);                     
            postOrderTraversal(root, q);

            return distance; 
        }

        private static bool postOrderTraversal(TreeNode root, TreeNode search)
        {
            if (root == null || distance > 0)
            {
                return false;
            }

            var left  = postOrderTraversal(root.left, search);
            var right = postOrderTraversal(root.right, search);

            if (root == search)
            {
                countToP = 0; 

                if(nodes.Contains(root))
                {
                    distance = 0;                    
                }
                else 
                {
                    nodes.Add(root);
                    map.Add(root, countToP);                    
                }

                return true; 
            }

            if (left == true || right == true)
            {
                countToP++;
                if (nodes.Contains(root))
                {
                    var value = map[root];
                    distance = countToP + value;
                    return false; // terminate early, protect distance value, caught by debugger
                }
                else
                {                    
                    nodes.Add(root);
                    map.Add(root, countToP);
                }

                return true; 
            }

            return false;
        }
    }
}
