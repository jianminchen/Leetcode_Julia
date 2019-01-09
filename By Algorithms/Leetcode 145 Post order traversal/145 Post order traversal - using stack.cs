using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _145_Post_Order_traversal___Solution_2
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
        static void Main(string[] args)
        {
        }

        public class Solution
        {
            public IList<int> PostorderTraversal(TreeNode root)
            {
                if (root == null)
                    return new List<int>();

                var stack = new Stack<TreeNode>();
                stack.Push(root);

                var list = new List<int>();
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    list.Add(current.val);

                    if (current.left != null)
                        stack.Push(current.left);

                    if (current.right != null)
                        stack.Push(current.right);
                }

                var array = list.ToArray();
                Array.Reverse(array);

                list.Clear();
                foreach (var item in array)
                    list.Add(item);

                return list;
            }
        }
    }
}
