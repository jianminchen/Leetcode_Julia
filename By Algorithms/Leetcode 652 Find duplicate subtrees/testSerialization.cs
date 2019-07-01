using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_duplicate_subtree
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
            RunTestcase2(); 
        }

        public static void RunTestcase()
        {
            var nodeA = new TreeNode(0);
            
            var nodeB1 = new TreeNode(0);
            var nodeB2 = new TreeNode(0);

            var nodeC1 = new TreeNode(0);
            var nodeC4 = new TreeNode(0);
            var nodeD8 = new TreeNode(0);

            nodeA.left  = nodeB1;
            nodeA.right = nodeB2;

            nodeB1.left  = nodeC1;
            nodeB2.right = nodeC4;

            nodeC4.right = nodeD8;

            FindDuplicateSubtrees(nodeA);
        }

        public static void RunTestcase2()
        {
            var nodeA = new TreeNode(0);

            var nodeB1 = new TreeNode(1);
            var nodeB2 = new TreeNode(11);

            var nodeC1 = new TreeNode(2);
            var nodeC4 = new TreeNode(24);
            var nodeD8 = new TreeNode(48);

            nodeA.left = nodeB1;
            nodeA.right = nodeB2;

            nodeB1.left = nodeC1;
            nodeB2.right = nodeC4;

            nodeC4.right = nodeD8;

            FindDuplicateSubtrees(nodeA);
        }

        /// <summary>
        /// 652 Find duplicate subtrees
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
        {
            if (root == null)
            {
                return new List<TreeNode>();
            }

            var dict = new Dictionary<string, HashSet<TreeNode>>();

            postorderTraverse(root, dict);

            var result = new List<TreeNode>();

            foreach (var pair in dict)
            {
                var set = pair.Value;
                if (set.Count > 1)
                {
                    var array = set.ToArray();
                    result.Add(array[0]);
                }
            }

            return result;
        }

        /// <summary>
        /// post order/ preorder/ inorder
        /// </summary>
        /// <param name="root"></param>
        /// <param name="visited"></param>
        /// <returns></returns>
        private static string postorderTraverse(TreeNode root, Dictionary<string, HashSet<TreeNode>> visited)
        {
            if (root == null)
                return "+";

            // make sure that it is post order traversal
            //                          Left                                                    right               
            var serialized = postorderTraverse(root.left, visited) + postorderTraverse(root.right, visited) + "(" + root.val + ")";

            if (!visited.ContainsKey(serialized))
            {
                visited.Add(serialized, new HashSet<TreeNode>());
            }

            visited[serialized].Add(root);

            return serialized;
        }
    }
}
