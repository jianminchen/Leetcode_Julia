using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _662_maximum_width_of_binary_tree
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
        internal class MyNode
        {
            public int      Value;
            public TreeNode Node;
            public MyNode(TreeNode node, int val)
            {
                Node = node;
                Value = val;
            }
        }

        static void Main(string[] args)
        {
        }

        /// <summary>
        /// Use integer to map the position of tree node
        ///     1
        ///   /   \
        ///  1     2
        ///  /\    /\
        /// 1  2  3  4
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int WidthOfBinaryTree(TreeNode root)
        {
            if (root == null)
                return 0;

            var queue = new Queue<MyNode>();
            var myNode = new MyNode(root, 1);

            queue.Enqueue(myNode);
            int maxWidth = 0;

            while (queue.Count > 0)
            {
                var size = queue.Count;
                var firstNo = 0;
                var lastNo = 0; 
                for (int i = 0; i < size; i++)
                {
                    var node = queue.Dequeue();
                    var value = node.Value;
                    if (i == 0)
                    {
                        firstNo = value;
                    }

                    if (i == size - 1)
                    {
                        lastNo = value; 
                    }

                    if (node.Node.left != null)
                    {                        
                        queue.Enqueue(new MyNode(node.Node.left, 2 * value - 1));
                    }

                    if (node.Node.right != null)
                    {
                        queue.Enqueue(new MyNode(node.Node.right, 2 * value));
                    }
                }

                var currentLevelWidth = lastNo - firstNo + 1;
                maxWidth = currentLevelWidth > maxWidth ? currentLevelWidth : maxWidth;
            }

            return maxWidth; 
        }
    }
}
