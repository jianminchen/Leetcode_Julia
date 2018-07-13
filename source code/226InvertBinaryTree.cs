using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*  May 26, 2015 http://arachnode.net/blogs/programming_challenges/archive/2009/09/25/recursive-tree-traversal-orders.aspx   
 * https://github.com/yuzhangcmu/LeetCode/blob/master/tree/TreeDemo.java
 
 */
namespace _226InvertBinaryTree
{
    internal class Program
    {
        private static readonly Queue<Node> Queue = new Queue<Node>();

        private static readonly Queue<Node> Queue2 = new Queue<Node>();

        private static void Main()
        {
            var node1 = new Node();
            var node2 = new Node();
            var node3 = new Node();
            var node4 = new Node();
            var node5 = new Node();
            var node6 = new Node();
            var node7 = new Node();

            node1.value = 1;
            node2.value = 2;
            node3.value = 3;
            node4.value = 4;
            node5.value = 5;
            node6.value = 6;
            node7.value = 7;

            node1.left = node2;
            node1.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.left = node6;
            node3.right = node7;          

            // June 16 invert tree
            Node resultInvert = invertBinaryTree(node1);
            Node resultInvertIter = invertBinaryTreeIterative(node1);

            Console.ReadLine();
        }



        /**
         * Latest update: on June 16, 2015
         * Leetcode: 
         * Invert a binary tree
         * Reference: 
         * http://www.zhihu.com/question/31202353
         * 
         * 7 lines of code - using recursion
         */
        public static Node invertBinaryTree(Node root)
        {
            if (root == null)
                return null;

            Node temp = root.left;
            root.left = root.right;
            root.right = temp;

            invertBinaryTree(root.left);
            invertBinaryTree(root.right);

            return root;
        }

        /**
         * Latest update: on June 16, 2015
         * Leetcode: Invert a binary tree
         * using iterative solution 
         */
        public static Node invertBinaryTreeIterative(Node root)
        {
            if (root == null)
                return null;

            Queue q = new Queue();
            q.Enqueue(root);

            /*
             * consider the queue: 
             */
            while (q.Count > 0)
            {
                Node nd = (Node)q.Dequeue();

                Node tmp = nd.left;
                nd.left = nd.right;
                nd.right = tmp;

                if (nd.left != null)
                    q.Enqueue(nd.left);
                if (nd.right != null)
                    q.Enqueue(nd.right);
            }

            return root;
        }
    }

    internal class Node
    {
        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public override string ToString()
        {
            return value.ToString();
        }
    }
}