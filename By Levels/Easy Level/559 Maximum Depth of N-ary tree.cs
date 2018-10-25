using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_559_Maximum_Depth_of_N_ary_tree
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

            static void Main(string[] args)
            {
            }

            public int MaxDepth(Node root)
            {
                if (root == null)
                    return 0;

                if (root.children == null)
                    return 1;

                var max = 0;
                foreach (var item in root.children)
                {
                    max = Math.Max(max, MaxDepth(item));
                }

                return 1 + max;
            }
        }
    }
}
