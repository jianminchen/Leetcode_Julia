using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _919_complete_binary_tree_inserter___queue_2
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class CBTInserter
    {
        private TreeNode root;
        private Queue<TreeNode> queue;
        /// <summary>
        /// source code is based on the idea from
        /// https://leetcode.com/problems/complete-binary-tree-inserter/discuss/178427/Java-BFS-straightforward-code-two-methods-Initialization-and-insert-time-O(1)-respectively.
        /// </summary>
        /// <param name="root"></param>
        public CBTInserter(TreeNode root)
        {
            this.root = root;
            queue = new Queue<TreeNode>();
        }

        public int Insert(int v)
        {
            queue.Clear(); // added after first submission
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node.left != null && node.right != null)
                {
                    queue.Enqueue(node.left);
                    queue.Enqueue(node.right);
                }
                else
                {
                    if (node.left == null)
                    {
                        node.left = new TreeNode(v);
                    }
                    else
                    {
                        node.right = new TreeNode(v);
                    }

                    return node.val;
                }
            }

            return -1;
        }

        public TreeNode Get_root()
        {
            return root;
        }
    }
}
