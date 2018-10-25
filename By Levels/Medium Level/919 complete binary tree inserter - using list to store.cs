using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _919_complete_binary_tree_inserter
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    public class CBTInserter
    {       
        public static void Main(string[] args)
        {
            RunTestcase2();
        }

        private static void RunTestcase1()
        {
            var root = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            root.left = node2;
            root.right = node3;

            node2.left = node4;
            node2.right = node5;

            node3.left = node6;

            var myInserter = new CBTInserter(root);

            myInserter.Insert(7);
            myInserter.Insert(8);

            var myRoot = myInserter.Get_root();
        }

        private List<TreeNode> tree;

        private static void RunTestcase2()
        {
            var root = new TreeNode(1);

            var myInserter = new CBTInserter(root);

            myInserter.Insert(2);
            myInserter.Insert(3);
            myInserter.Insert(4);

            var myRoot = myInserter.Get_root();
        }
        /// <summary>
        /// O(N) insertion - traverse the tree
        /// </summary>
        /// <param name="root"></param>
        public CBTInserter(TreeNode root)
        {
            tree = new List<TreeNode>();
            tree.Add(root);

            for (int i = 0; i < tree.Count; i++)
            {
                if (tree[i].left != null)
                {
                    tree.Add(tree[i].left);
                }

                if (tree[i].right != null)
                {
                    tree.Add(tree[i].right);
                }
            }
        }

        public int Insert(int v)
        {
            int size = tree.Count;
            var node = new TreeNode(v);

            tree.Add(node);
            int index = (size - 1) / 2;
            if (size % 2 == 1)
            {
                tree[index].left = node;
            }
            else
            {
                tree[index].right = node;
            }

            return tree[index].val;
        }

        public TreeNode Get_root()
        {
            return tree[0];
        }
    }
}
