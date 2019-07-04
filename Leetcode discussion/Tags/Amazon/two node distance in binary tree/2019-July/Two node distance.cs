using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTwoNodesDistance_2019
{
    class Program
    {
        internal class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int number)
            {
                Value = number;
            }
        }

        static void Main(string[] args)
        {
            // calculate two nodes distance
            RunTestcase();
        }

        /// <summary>
        /// inorder traversal - 1 2 3 4 5 6 7
        /// </summary>
        public static void RunTestcase()
        {
            var root = new Node(4);
            root.Left = new Node(2);
            root.Left.Left = new Node(1);
            root.Left.Right = new Node(3);
            root.Right = new Node(6);
            root.Right.Left = new Node(5);
            root.Right.Right = new Node(7);

            // distance should be 4 
            var distance = FindDistance(root, root.Left.Right, root.Right.Right);
            Debug.Assert(distance == 4);

            var distance2 = FindDistance(root, root.Left.Right, root.Left.Left);
            Debug.Assert(distance2 == 2);
        }

        /// <summary>
        /// code review on July 4, 2019
        /// </summary>
        /// <param name="root"></param>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static int FindDistance(Node root, Node p, Node q)
        {
            var rootToP = new List<Node>();
            var rootToQ = new List<Node>();

            FindPath(root, p, rootToP);
            FindPath(root, q, rootToQ);

            if (rootToP.Count == 0 || rootToQ.Count == 0)
            {
                return 0;
            }

            // find first node not equal 
            int index = 0;
            int length1 = rootToP.Count;
            int length2 = rootToQ.Count;

            while (index < Math.Min(length1, length2) &&
                   rootToP[index] == rootToQ[index])
            {
                index++;
            }

            // Root_to_P  + Root_to_Q - 2 * Root_to_LowestCommon_Ancestor
            //(length1 - 1) + (length2 - 1) - (2 * (index - 1))
            return length1 + length2 - 2 * index;
        }

        /// <summary>
        /// Do a preorder search for the node
        /// Path should be from root node to search node
        /// Understand backtracking, use one list for all nodes in the tree to find path
        /// Avoid time out, copy list etc. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="search"></param>
        /// <param name="path"></param>
        /// <param name="searchPath"></param>
        public static bool FindPath(Node root, Node search, IList<Node> path)
        {
            if (root == null)
            {
                return false;
            }

            path.Add(root);

            if (root == search)
            {                                
                return true;
            }                      

            var left  = FindPath(root.Left, search,  path);
            var right = FindPath(root.Right, search, path);

            if (!(left || right))
            {
                path.RemoveAt(path.Count - 1);
                return false;
            }

            return true; 
        }
    }
}