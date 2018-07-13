using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreePostOrderTraversalIterative
{
    class Program
    {
        static void Main(string[] args)
        {
            /**
             * test case: 
             *   Tree
             *      1
             *    2   3
             *  4  5 6  7
             *  Post order Traversal: 4 5 2 6 7 3 1
             */
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

            Console.WriteLine("PostorderTraversal");

            PostorderTraversal(node1);

            // June 2, 2015 
            Console.WriteLine("Post order traversal Iterative");
            postorderTraversal_Iterative(node1);    

        }


        private static void PostorderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            PostorderTraversal(node.left);

            PostorderTraversal(node.right);

            Console.WriteLine(node.value);
        }

        /** 
        * https://github.com/yuzhangcmu/LeetCode/blob/master/tree/TreeDemo.java
        *  后序遍历迭代解法 
        *  
        *  从左到右的后序 与从右到左的前序的逆序是一样的，所以就简单喽！ 哈哈
        *  用另外一个栈进行翻转即可喽 
         *  julia's comment: 
         *  1. When to push node into stack for output, second stack? 
         *     when the first stack pops a node, it is time to push the node into output stack; 
         *     otherwise, node is gone. 
         *     when the first stack pushs a node into the stack, second stack do nothing. 
         *  2. Post order:  left, right, root   
     
        */
        public static void postorderTraversal_Iterative(Node root)
        {
            if (root == null)
            {
                return;
            }

            Stack s = new Stack();
            Stack outS = new Stack();

            s.Push(root);
            while (s.Count > 0)
            {
                Node cur = (Node)s.Pop();
                outS.Push(cur);

                if (cur.left != null)
                {
                    s.Push(cur.left);
                }
                if (cur.right != null)
                {
                    s.Push(cur.right);
                }
            }

            while (outS.Count > 0)
            {
                Node cur = (Node)outS.Pop();
                Console.WriteLine(cur.value + " ");
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
}
