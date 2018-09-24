using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_872_leaf_similar_trees
{
    /// <summary>
    /// 872. Leaf-Similar Trees
    /// </summary>
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        static void Main(string[] args)
        {
            var tree1 = getTreeNode1();
            var tree2 = getTreeNode2();

            var result = LeafSimilar(tree1, tree2); 
        }

        private static TreeNode getTreeNode1() 
        {
            var root3 = new TreeNode(3);

            var root5 = new TreeNode(5);
            var root1 = new TreeNode(1);

            var root6 = new TreeNode(6);
            var root2 = new TreeNode(2);

            var root7 = new TreeNode(7);
            var root4 = new TreeNode(4);

            var root9 = new TreeNode(9);
            var root8 = new TreeNode(8); 

            root3.left = root5;
            root3.right = root1; 

            root5.left = root6;
            root5.right = root2;

            root2.left  = root7;
            root2.right = root4;

            root1.left = root9;
            root1.right = root8;

            return root3;
        }

        private static TreeNode getTreeNode2()
        {
            var root3 = new TreeNode(3);

            var root5 = new TreeNode(5);
            var root1 = new TreeNode(1);

            var root6 = new TreeNode(6);
            var root2 = new TreeNode(2);

            var root7 = new TreeNode(7);
            var root4 = new TreeNode(4);

            var root9 = new TreeNode(9);
            var root8 = new TreeNode(8);

            root3.left  = root5;
            root3.right = root1;

            root5.left  = root6;
            root5.right = root7;

            root1.left  = root4;
            root1.right = root2;

            root2.left = root9;
            root2.right = root8;

            return root3;
        }

        public static bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var list1 = new List<TreeNode>();
            var list2 = new List<TreeNode>();

            preorderTraversal(root1, list1);
            preorderTraversal(root2, list2);

            return compareTwoList(list1, list2);
        }

        private static void preorderTraversal(TreeNode root, IList<TreeNode> leaves)
        {
            if (root == null)
                return;

            if (root.left == null && root.right == null)
            {
                leaves.Add(root);
                return;
            }

            preorderTraversal(root.left, leaves);
            preorderTraversal(root.right, leaves);
        }

        private static bool compareTwoList(IList<TreeNode> list1, IList<TreeNode> list2)
        {
            if (list1 == null && list2 == null)
                return true;

            if (list1 == null || list2 == null)
                return false;

            var length1 = list1.Count;
            var length2 = list2.Count;

            if (length1 != length2)
                return false;

            for (int i = 0; i < length1; i++)
            {
                if (list1[i].val != list2[i].val)
                    return false;
            }

            return true;
        }
    }
}
