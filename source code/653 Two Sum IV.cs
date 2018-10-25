using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_653_Two_Sum_IV
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

        public bool FindTarget(TreeNode root, int k)
        {
            var nodes = new List<int>(); 

            inorderTraversal(root, nodes);

            return twoPointerTwosum(nodes, k); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private static void inorderTraversal(TreeNode root, List<int> nodes)
        {
            if (root == null)
                return;

            inorderTraversal(root.left, nodes);

            nodes.Add(root.val);

            inorderTraversal(root.right, nodes); 
        }

        private static bool twoPointerTwosum(List<int> nodes, int target)
        {
            int start = 0;
            int end = nodes.Count - 1 ;

            while (start < end)
            {
                var current = nodes[start] + nodes[end];
                if (current == target)
                    return true;

                if (current < target)
                    start++;

                if (current > target)
                    end--;
            }

            return false; 
        }
    }
}
