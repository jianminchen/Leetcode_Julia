using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _652_Find_duplicate_subtrees
{
    public class TreeNode
    {
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
        /// source code is based on the idea from 
        /// https://leetcode.com/problems/find-duplicate-subtrees/discuss/160015/Python-%2B-DFS-tm
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<TreeNode> FindDuplicateSubtrees(TreeNode root)
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
        /// time compleixty is O(N), N is total number of nodes in the tree
        /// change the base case return "+" since failed test case
        ///   0    0
        ///  /      \
        /// 0        0
        /// </summary>
        /// <param name="root"></param>
        /// <param name="visited"></param>
        /// <returns></returns>
        private static string postorderTraverse(TreeNode root, Dictionary<string, HashSet<TreeNode>> visited)
        {
            if (root == null)
                return "+";    // change "" to "+" because we need to tell that left from right child        
            
            // make sure that it is post order traversal
            //                          left                                   right               
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
