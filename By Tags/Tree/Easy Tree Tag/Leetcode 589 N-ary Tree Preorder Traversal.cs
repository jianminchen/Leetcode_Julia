using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_589_N_ary_Tree_Preorder_Traversal
{
    class Program
    {
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }
            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }

        static void Main(string[] args)
        {
        }

        public static IList<int> Preorder(Node root)
        {
            var nodes = new List<int>();
            if (root == null)
                return nodes;

            preorderTraversal(root, nodes);

            return nodes;
        }

        /// <summary>
        /// assume root is not null
        /// </summary>
        /// <param name="root"></param>
        /// <param name="nodes"></param>
        private static void preorderTraversal(Node root, List<int> nodes)
        {
            nodes.Add(root.val);

            if(root.children == null)
                return; 

            foreach(var item in root.children)
            {
                preorderTraversal(item, nodes); 
            }
        }
    }
}
