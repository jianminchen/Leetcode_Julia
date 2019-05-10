using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common_ancestor_path2
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
        }

        /// <summary>
        /// study code on May 10, 2019
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/discuss/65371/Java-solution-by-finding-the-path-for-each-node
        /// I push myself and learn how to use backtrack to save space complexity O(logN) instead of O(N * N)
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if (root == null) return null;
            if (p == null || q == null) return null;

            var p_path = new List<TreeNode>();
            var q_path = new List<TreeNode>();

            findPath(root, p, p_path);
            findPath(root, q, q_path);

            int minLength = Math.Min(p_path.Count, q_path.Count);

            int lastOne = 0;
            for (int i = 0; i < minLength; i++)
            {
                if (p_path[i] == q_path[i])
                {
                    lastOne = i;
                }
            } 
            
            return p_path[lastOne];
        }

        /// <summary>
        /// code review May 10, 2019
        /// backtracking is so beautiful. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="search"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool findPath(TreeNode root, TreeNode search, IList<TreeNode> path)
        {
            if (root == null)
            {
                return false;
            }

            path.Add(root);

            if (root == search)
            {
                return true;
            }

            if (findPath(root.left, search, path) || findPath(root.right, search, path))
            {
                return true;
            }

            // backtracking 
            path.RemoveAt(path.Count - 1);

            return false;
        }
    }
}
