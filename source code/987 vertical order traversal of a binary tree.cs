using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _987_vertical_order_traversal_of_a_binary_tree
{
    public class TreeNode {
       public int val;
       public TreeNode left;
       public TreeNode right;
       public TreeNode(int x) { val = x; }
    }

    class Program
    {
        /// <summary>
        /// Input:
        /// [0,5,1,9,null,2,null,null,null,null,3,4,8,6,null,null,null,7]
        /// Output:
        /// [[7,9],[5,6],[0,2,4],[1,3],[8]]
        /// Expected:
        /// [[9,7],[5,6],[0,2,4],[1,3],[8]]
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var node0 = new TreeNode(0);
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);
            var node8 = new TreeNode(8);
            var node9 = new TreeNode(9);

            node0.left  = node5;
            node0.right = node1;

            node5.left = node9;
            node1.left = node2;

            node2.right = node3;

            node3.left = node4;
            node3.right = node8;

            node4.left = node6;
            node6.left = node7;

            var result = VerticalTraversal(node0);
        }

        /// <summary>
        /// source code is to copy idea from the blog
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
