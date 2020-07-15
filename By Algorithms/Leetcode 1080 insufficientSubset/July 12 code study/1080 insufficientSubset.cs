using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1080_insufficientSubset
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        /// <summary>
        /// 1080 sufficient subset 
        /// July 13, 2020
        /// </summary>
        /// <param name="root"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            if (root == null)
            {
                return null;
            }

            if (postOrderTraversal(root, limit, 0))
            {
                return root;
            }
            else
            {
                return null;
            }
        }

        /// take some risk
        /// make code simple
        /// if the node is the leaf node of original tree before nodes are removed,
        ///  compare sum with target; only compare when it is leaf node
        /// else 
        ///  post order traversal - a node without any children may not be leaf node
        //   check it's left and right return
        public bool postOrderTraversal(TreeNode node, int target, int sum)
        {
            if (node == null)
            {
                return sum >= target;
            }

            sum += node.val;

            var left = postOrderTraversal(node.left, target, sum);
            var right = postOrderTraversal(node.right, target, sum);

            if (!left)
            {
                node.left = null;
            }

            if (!right)
            {
                node.right = null;
            }

            if (node.left == null && node.right == null)
            {
                // test case 1: this applies to three node in the tree, 
                //   bottom up, 
                //   first one: -99 left, second one: -99 right, last one: 1 root
                // test case 3: Only apply to three nodes, node 4 and node -5, node 2
                // leaf node 4, return true & true
                // leaf node -5, return false & false
                // node 2, return false
                return left & right;
            }
            else
            {
                // test case 3: root node 1
                return true;
            }
        }    
    }
}
