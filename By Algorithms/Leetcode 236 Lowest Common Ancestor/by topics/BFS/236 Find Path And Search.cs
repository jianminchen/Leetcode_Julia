using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _236_lowest_common___path
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
        /// https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/discuss/65278/My-solution-may-be-not-so-goodbut-clear
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var m = new Dictionary<TreeNode, TreeNode>();

            // breadth first search walking tree
            var queue = new Queue<TreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.left != null)
                {
                    m.Add(current.left, current);

                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    m.Add(current.right, current);
                    queue.Enqueue(current.right);
                }
            }

            // build route from p to root node
            var nodes = new HashSet<TreeNode>();
            var pToRoot = p;

            while (pToRoot != root)
            {
                nodes.Add(pToRoot);
                pToRoot = m[pToRoot];
            }

            nodes.Add(root);

            // look up node from q to root to see if it is in p to root. 
            var qToRoot = q;
            while (!nodes.Contains(qToRoot))
            {
                qToRoot = m[qToRoot];
            }

            return qToRoot;
        }
    }
}
