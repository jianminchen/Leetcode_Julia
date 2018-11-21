using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _623_Add_one_row_to_tree_II
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
            RunTestcase3();
        }

        public static void RunTestcase()
        {
            var node4 = new TreeNode(4);
            var node2 = new TreeNode(2);
            var node6 = new TreeNode(6);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            var node5 = new TreeNode(5);

            node4.left = node2;
            node4.right = node6;
            node2.left = node3;
            node2.right = node1;
            node6.left = node5;

            var result = AddOneRow(node4, 1, 2);
        }

        public static void RunTestcase2()
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;

            var result = AddOneRow(node1, 5, 4);
        }

        // [4,2,6,3,1,5], 1, 3 
        // [4,2,6,1,1,1,null,3,null,null,1,5]
        // [4,2,6,1,1,1,1,   3,null,null,1,5]
        public static void RunTestcase3()
        {
            var node4 = new TreeNode(4);
            var node2 = new TreeNode(2);
            var node6 = new TreeNode(6);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1);
            var node5 = new TreeNode(5);

            node4.left = node2;
            node4.right = node6;
            node2.left = node3;
            node2.right = node1;
            node6.left = node5;

            var result = AddOneRow(node4, 1, 3);
        }

        /// <summary>
        /// Add one row to tree at level specified by argument: level
        /// the node's value is specified by argument: value
        /// Tree's level starts from 1. 
        /// If level is 1, then add a new root, original root will be left 
        /// child of new root. 
        /// </summary>
        /// <param name="root"></param>
        /// <param name="value"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        public static TreeNode AddOneRow(TreeNode root, int value, int level)
        {
            if (level == 0 || level == 1)
            {
                var newroot = new TreeNode(value);

                newroot.left = level == 1 ? root : null;
                newroot.right = level == 0 ? root : null;

                return newroot;
            }

            if (root != null && level >= 2)
            {
                root.left  = AddOneRow(root.left,  value, level > 2 ? level - 1 : 1);
                root.right = AddOneRow(root.right, value, level > 2 ? level - 1 : 0);
            }

            return root;
        }
    }
}
