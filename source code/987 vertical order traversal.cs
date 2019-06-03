using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _987_vertical_order_traversal
{
    class Program
    {
        public class TreeNode {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
            RunTestcase2();
        }

        public static void RunTestcase1()
        {
            var node3 = new TreeNode(3);
            var node9 = new TreeNode(9);
            var node20 = new TreeNode(20);
            var node15 = new TreeNode(15);
            var node7 = new TreeNode(7);

            node3.left = node9;
            node3.right = node20;
            node20.left = node15;
            node20.right = node7;

            var result = VerticalTraversal(node3); 
        }

        public static void RunTestcase2()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(105);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7; 

            var result = VerticalTraversal(node1); 
        }

        /// <summary>
        /// June 3, 2019
        /// How to choose a data structure to store all information we need in the traveral of tree using 
        /// preorder traversal? 
        /// The level of the node and horizontal positions are saved. 
        /// The root node's position is (0,0). 
        /// 
        /// study code: 
        /// http://anothercasualcoder.blogspot.com/2019/02/use-of-three-sorted-data-structures-in-c.html
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public static IList<IList<int>> VerticalTraversal(TreeNode root)
        {
            var vertical = new SortedDictionary<int, SortedList<int, SortedSet<int>>>();

            VerticalTraversal(root, 0, 0, vertical);

            var solution = new List<IList<int>>();
            foreach (int horizontal in vertical.Keys)
            {
                var list = new List<int>();
                foreach (int level in vertical[horizontal].Keys)
                {
                    foreach (int element in vertical[horizontal][level])
                    {
                        list.Add(element);
                    }
                }

                solution.Add(list);
            }

            return solution;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="horizontal"></param>
        /// <param name="level"></param>
        /// <param name="vertical"></param>
        private static void VerticalTraversal(TreeNode root,
                                        int horizontal,
                                        int level,
                                        SortedDictionary<int, SortedList<int, SortedSet<int>>> vertical)
        {
            if (root == null)
            {
                return;
            }

            if (!vertical.ContainsKey(horizontal))
            {
                vertical.Add(horizontal, new SortedList<int, SortedSet<int>>());
            }

            if (!vertical[horizontal].ContainsKey(level))
            {
                vertical[horizontal].Add(level, new SortedSet<int>());
            }

            vertical[horizontal][level].Add(root.val);

            VerticalTraversal(root.left,  horizontal - 1, level + 1, vertical);
            VerticalTraversal(root.right, horizontal + 1, level + 1, vertical);
        }
    }
}
