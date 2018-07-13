using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _144BinaryTreePreorderTraversal
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

            Console.WriteLine("PreorderTraversal");

            PreorderTraversal(node1);

            Console.WriteLine("PreorderTraversalIterative");
            ArrayList list = preorderTraversalIterative(node1);
            foreach (Object s in list)
            {
                int tmp = (int)s;
                Console.WriteLine(tmp);
            }
       
            Console.ReadLine();
        }

        private static void PreorderTraversal(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.value.ToString());

            PreorderTraversal(node.left);
            PreorderTraversal(node.right);
        }


        private static ArrayList preorderTraversalIterative(Node root)
        {
            ArrayList result = new ArrayList();
            Node p = new Node();

            Stack s = new Stack();

            p = root;
            if (p != null) s.Push(p);

            while (s.Count > 0)
            {
                p = (Node)s.Peek();

                s.Pop();

                result.Add(p.value);

                if (p.right != null) s.Push(p.right);
                if (p.left != null) s.Push(p.left);
            }

            return result;
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