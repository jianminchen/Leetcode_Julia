using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _979_distribute_coins_in_binary_tree
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
            var node0  = new TreeNode(0);
            var node0B = new TreeNode(0);
            var node0C = new TreeNode(0);
            var node4  = new TreeNode(4);
            var node0D = new TreeNode(0);
            var node3  = new TreeNode(3);
            var node0E = new TreeNode(0);

            node0.left   = node0B;
            node0.right  = node0C;

            node0B.left  = node4;
            node0B.right = node0D;

            node0C.left  = node3;
            node0C.right = node0E;

            DistributeCoins(node0);

            Console.WriteLine(coinsMoved);
        }

        public static int coinsMoved; 
        public static int DistributeCoins(TreeNode root)
        {
            if (root == null)
                return 0;

            coinsMoved = 0;

            postOrderTraversal(root);

            return coinsMoved;
        }

        /// <summary>
        /// https://leetcode.com/problems/distribute-coins-in-binary-tree/discuss/221939/C%2B%2B-with-picture-post-order-traversal
        /// go over the example in the above discuss 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static int postOrderTraversal(TreeNode root)
        {
            if (root == null)
                return 0;

            var left  = postOrderTraversal(root.left);
            var right = postOrderTraversal(root.right);

            coinsMoved += Math.Abs(left) + Math.Abs(right);

            return left + right + root.val - 1;
        }
    }
}
