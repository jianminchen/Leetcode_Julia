using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeTwoNodesDistance
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

        public static int FindDistance(Node root, Node p, Node q)
        {
            IList<Node> possiblePath_1 = new List<Node>();
            IList<Node> possiblePath_2 = new List<Node>();

            IList<Node> searchPath_1 = new List<Node>();
            IList<Node> searchPath_2 = new List<Node>();

            FindPath(root, p, possiblePath_1, ref searchPath_1);
            FindPath(root, q, possiblePath_2, ref searchPath_2);

            if (searchPath_1.Count == 0 || searchPath_2.Count == 0)
            {
                return 0;
            }

            // find first node not equal 
            int index = 0;
            int length1 = searchPath_1.Count;
            int length2 = searchPath_2.Count;

            while (index < Math.Min(length1, length2) &&
                searchPath_1[index] == searchPath_2[index])
            {
                index++;
            }

            //(length1 - 1) + (length2 - 1) - (2 * (index - 1))
            return length1 + length2 - 2 * index;
        }

        /// <summary>
        /// Do a preorder search for the node
        /// </summary>
        /// <param name="root"></param>
        /// <param name="search"></param>
        /// <param name="possiblePath"></param>
        /// <param name="searchPath"></param>
        public static void FindPath(Node root, Node search, IList<Node> possiblePath, ref IList<Node> searchPath)
        {
            if (root == null || searchPath.Count > 0)
            {
                return;
            }

            if (root == search)
            {
                searchPath = possiblePath;
                searchPath.Add(search);
                return;
            }

            possiblePath.Add(root);
            IList<Node> leftBranch = new List<Node>(possiblePath);
            IList<Node> rightBranch = new List<Node>(possiblePath);

            FindPath(root.Left, search, leftBranch, ref searchPath);
            FindPath(root.Right, search, rightBranch, ref  searchPath);
        }
    }
}