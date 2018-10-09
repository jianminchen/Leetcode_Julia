using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _919_complete_binary_tree_insert____queue_II
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>  
    /// </summary>
    public class CBTInserter
    {
        public static void Main(string[] args)
        {
            RunTestcase2();
        }

        private static void RunTestcase1()
        {
            var root = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            root.left = node2;
            root.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.left = node6;

            var myInserter = new CBTInserter(root);

            myInserter.Insert(7);
            myInserter.Insert(8);

            var myRoot = myInserter.Get_root();
        }

        private static void RunTestcase2()
        {
            var root = new TreeNode(1);

            var myInserter = new CBTInserter(root);

            myInserter.Insert(2);
            myInserter.Insert(3);
            myInserter.Insert(4);

            var myRoot = myInserter.Get_root();
        }

        private TreeNode root;
        private Queue<TreeNode> queue;
        /// <summary>
        /// source code is based on the idea from
        /// https://leetcode.com/problems/complete-binary-tree-inserter/discuss/178949/c++-use-queue-beat-100
        /// Iterate by level, remove all levels from queue except the last two levels
        /// </summary>
        /// <param name="root"></param>
        public CBTInserter(TreeNode root)
        {
            this.root = root;
            queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                // if the root has no children or only one child, then the root node should stay inside the queue
                //var current = queue.Dequeue();  
                var current = queue.Peek();
                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }

                if (current.right != null)
                {
                    queue.Dequeue(); // remove the node from the queue since left and right child both are occupied
                    queue.Enqueue(current.right);
                }

                if (current.left == null || current.right == null) // Do not mix current with root!
                {
                    break;
                }
            }
        }

        /// <summary>
        /// O(1) time complexity
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public int Insert(int v)
        {
            //var current = queue.Dequeue();
            var current = queue.Peek();

            var node = new TreeNode(v);

            if (current.left == null)
            {
                current.left = node;
            }
            else
            {
                current.right = node;
                queue.Dequeue();
            }

            queue.Enqueue(node);  // Do not forget!
            return current.val;
        }

        public TreeNode Get_root()
        {
            return root;
        }
    }
}