using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_437
{       
    public class Solution
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

        public int PathSum(TreeNode root, int sum)
        {
            if (root == null)
                return 0;
            var map = new Dictionary<int, int>();
            var totalPaths = 0;
            preorderTraversal(root, sum, map, 0, ref totalPaths);

            return totalPaths;
        }

        /// <summary>
        /// preorder traversal the tree, time complexity for traversal is O(N), N is total number of nodes in the tree. 
        /// For every node, look up hashtable for the value sum - prefixSum, time complexity is O(1). 
        /// So total time complexity will be O(N). 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <param name="map"></param>
        /// <param name="prefixSum"></param>
        /// <param name="totalPaths"></param>
        private static void preorderTraversal(TreeNode root, int sum, Dictionary<int, int> map, int prefixSum, ref int totalPaths)
        {
            // base case
            if (root == null)
                return;

            var current = root.val;
            var newPrefixSum = prefixSum + current;
            var search = newPrefixSum - sum;
            if (map.ContainsKey(search))
            {
                totalPaths += map[search];
            }

            if (search == 0)
                totalPaths += 1;

            if (!map.ContainsKey(newPrefixSum))
            {
                map.Add(newPrefixSum, 0);
            }

            map[newPrefixSum]++;

            preorderTraversal(root.left, sum, new Dictionary<int, int>(map), newPrefixSum, ref totalPaths);
            preorderTraversal(root.right, sum, new Dictionary<int, int>(map), newPrefixSum, ref totalPaths);
        }
    }
}
