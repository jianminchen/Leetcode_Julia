using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nextRightNode
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }
            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        /// <summary>
        /// Leetcode 117 
        /// Next right node
        /// Level by level order traversal so the current node's next is next node in the same level. 
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public Node Connect(Node root)
        {
            if (root == null)
                return root;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var levelCount = queue.Count;
                int index = 0;
                Node previous = null;

                while (index < levelCount)
                {
                    var current = queue.Dequeue();

                    if (previous != null)
                    {
                        previous.next = current; 
                    }

                    // add left and right child to the queue
                    if (current.left != null)
                    {
                        queue.Enqueue(current.left); 
                    }

                    if (current.right != null)                    
                    {
                        queue.Enqueue(current.right); 
                    }

                    previous = current;
                    index++; 
                }               
            }

            return root; 
        }
    }
}
